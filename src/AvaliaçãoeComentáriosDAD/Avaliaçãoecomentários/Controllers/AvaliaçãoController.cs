using Avaliaçãoecomentários.Data;
using Avaliaçãoecomentários.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Avaliaçãoecomentários.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvaliacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliação>>> Get()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliação>> GetById(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null) return NotFound();
            return avaliacao;
        }

        [HttpPost]
        public async Task<ActionResult<Avaliação>> Post(Avaliação avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Avaliação avaliacao)
        {
            if (id != avaliacao.Id) return BadRequest();
            _context.Entry(avaliacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null) return NotFound();

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
