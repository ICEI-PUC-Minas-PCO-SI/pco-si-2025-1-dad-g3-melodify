using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autenticacao_e_Gestao_do_Usuario.Models;

namespace Autenticacao_e_Gestao_do_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenhasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SenhasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Senhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Senha>>> GetSenha()
        {
            return await _context.Senha.ToListAsync();
        }

        // GET: api/Senhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Senha>> GetSenha(int id)
        {
            var senha = await _context.Senha.FindAsync(id);

            if (senha == null)
            {
                return NotFound();
            }

            return senha;
        }

        // PUT: api/Senhas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSenha(int id, Senha senha)
        {
            if (id != senha.Id)
            {
                return BadRequest();
            }

            _context.Entry(senha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SenhaExists(id))
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

        // POST: api/Senhas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Senha>> PostSenha(Senha senha)
        {
            _context.Senha.Add(senha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSenha", new { id = senha.Id }, senha);
        }

        // DELETE: api/Senhas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSenha(int id)
        {
            var senha = await _context.Senha.FindAsync(id);
            if (senha == null)
            {
                return NotFound();
            }

            _context.Senha.Remove(senha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SenhaExists(int id)
        {
            return _context.Senha.Any(e => e.Id == id);
        }
    }
}
