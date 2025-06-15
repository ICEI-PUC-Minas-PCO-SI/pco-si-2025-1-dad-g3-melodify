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
            try
            {
                var avaliacoes = await _context.Avaliacoes.ToListAsync();
                return Ok(avaliacoes);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao buscar as avaliações." });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliação>> GetById(int id)
        {
            try
            {
                var avaliacao = await _context.Avaliacoes.FindAsync(id);
                if (avaliacao == null)
                    return NotFound(new { mensagem = "Avaliação não encontrada." });

                return Ok(avaliacao);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao buscar a avaliação." });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Avaliação>> Post(Avaliação avaliacao)
        {
            try
            {
                if (avaliacao == null)
                    return BadRequest(new { mensagem = "Dados da avaliação inválidos." });

                _context.Avaliacoes.Add(avaliacao);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar a avaliação." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Avaliação avaliacao)
        {
            if (id != avaliacao.Id)
                return BadRequest(new { mensagem = "O ID da URL não corresponde ao ID da avaliação." });

            try
            {
                var avaliacaoExistente = await _context.Avaliacoes.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
                if (avaliacaoExistente == null)
                    return NotFound(new { mensagem = "Avaliação não encontrada para atualização." });

                _context.Entry(avaliacao).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar a avaliação." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var avaliacao = await _context.Avaliacoes.FindAsync(id);
                if (avaliacao == null)
                    return NotFound(new { mensagem = "Avaliação não encontrada para exclusão." });

                _context.Avaliacoes.Remove(avaliacao);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao excluir a avaliação." });
            }
        }
    }
}
