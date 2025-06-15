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
            try
            {
                var comentarios = await _context.Comentarios.ToListAsync();
                return Ok(comentarios);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao buscar os comentários." });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetById(int id)
        {
            try
            {
                var comentario = await _context.Comentarios.FindAsync(id);
                if (comentario == null)
                    return NotFound(new { mensagem = "Comentário não encontrado." });

                return Ok(comentario);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao buscar o comentário." });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Comentario>> Post(Comentario comentario)
        {
            try
            {
                if (comentario == null)
                    return BadRequest(new { mensagem = "Dados do comentário inválidos." });

                _context.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = comentario.Id }, comentario);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar o comentário." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Comentario comentario)
        {
            if (id != comentario.Id)
                return BadRequest(new { mensagem = "O ID da URL não corresponde ao ID do comentário." });

            try
            {
                var comentarioExistente = await _context.Comentarios.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
                if (comentarioExistente == null)
                    return NotFound(new { mensagem = "Comentário não encontrado para atualização." });

                _context.Entry(comentario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar o comentário." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _context.Comentarios.FindAsync(id);
                if (comentario == null)
                    return NotFound(new { mensagem = "Comentário não encontrado para exclusão." });

                _context.Comentarios.Remove(comentario);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao excluir o comentário." });
            }
        }
    }
}
