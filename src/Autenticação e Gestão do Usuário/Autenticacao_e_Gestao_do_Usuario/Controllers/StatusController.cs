using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autenticacao_e_Gestao_do_Usuario.Models;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Authorization;
using Autenticacao_e_Gestao_do_Usuario.Models.DTO;

namespace Autenticacao_e_Gestao_do_Usuario.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            var status = await _context.Status.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        // POST: api/Status
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Status>> PostStatus(NovoStatusDto status)
        {
            var statusFull = new Status
            {
                Id = 0,
                Descricao = status.Descricao,
                Criado_Em = DateTime.UtcNow,
                Alterado_Em = DateTime.UtcNow
            };
            _context.Status.Add(statusFull);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = statusFull.Id }, statusFull);
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PutStatus(int id, AlterarStatusDto status)
        {
            var statusOri = await _context.Status.FindAsync(id);

            if (statusOri == null)
            {
                return NotFound();
            }

            if (id != statusOri.Id)
            {
                return BadRequest();
            }

            statusOri.Descricao = status.Descricao;
            statusOri.Alterado_Em = DateTime.UtcNow;

            _context.Entry(statusOri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Status atualizado com sucesso." });//NoContent();
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Status deletado com sucesso." });//NoContent();
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.Id == id);
        }
    }
}