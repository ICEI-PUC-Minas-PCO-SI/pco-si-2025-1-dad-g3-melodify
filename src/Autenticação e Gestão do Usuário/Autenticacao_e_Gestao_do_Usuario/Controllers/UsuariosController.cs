using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autenticacao_e_Gestao_do_Usuario.Models;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Autenticacao_e_Gestao_do_Usuario.Models.DTO;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Humanizer;


namespace Autenticacao_e_Gestao_do_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(Roles = "Administrador,Usuario")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Usuario")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Usuario")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            usuario.Senha = BC.HashPassword(usuario.Senha);

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> PostUsuario(CadastroDto usuario)
        {
            usuario.Senha = BC.HashPassword(usuario.Senha);

            var usuarioFull = new Usuario
            {
                Id = 0,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Perfil = usuario.Perfil,
                Status = 1,
                Criado_Em = DateTime.UtcNow,
                Alterado_Em = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuarioFull);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuarioFull.Id }, usuarioFull);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            //SenhasController senhaController = new SenhasController(_context);
            //await senhaController.DeleteSenha(id);

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == model.Email);

            if (usuario == null || (!BC.Verify(model.Senha, usuario.Senha))) 
            {
                return NotFound(new {Message = "Email e/ou senha inválidos!"});
            }

            var jwtToken = GenerateJwtToken(usuario);

            return Ok(new {jwt = jwtToken });
        }

        private string GenerateJwtToken(Usuario usuario) 
        { 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("T6uP9qJwZ1mB7xDcL0eRfVtYgUhNjMzX\r\n");
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Perfil),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
