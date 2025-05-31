using Avaliaçãoecomentários.Data;
using Avaliaçãoecomentários.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Avaliaçãoecomentários.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComentarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> Get()
        {
            return await _context.Comentarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetById(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return NotFound();
            return comentario;
        }

        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = comentario.Id }, comentario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Comentario comentario)
        {
            if (id != comentario.Id) return BadRequest();
            _context.Entry(comentario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return NotFound();

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
