using Microsoft.AspNetCore.Mvc;
using RecomendacaoDeMusicas.Data;
using RecomendacaoDeMusicas.Models;

namespace RecomendacaoDeMusicas.Controllers
{
        [ApiController]
        [Route("api/[controller]")]

        public class RecomendacaoController : ControllerBase
        {
            private readonly AppDbContext _context;

            public RecomendacaoController(AppDbContext context)
            {
                _context = context;
            }

            // get: api/recomendacao/byGenero?genero={genre}
            [HttpGet("byGenero")]
            public ActionResult<IEnumerable<Musica>> GetByGenero([FromQuery] string genero)
            {
                var musicas = _context.Musicas
                    .Where(musica => musica.Genre != null && musica.Genre.ToLower().Contains(genero.ToLower()))
                    .ToList();

                if(musicas.Count == 0)
                {
                    return NotFound("Não há musicas para recomendar com esse gênero.");
                }

                return Ok(musicas);
            }

            // get: api/recomendacao/byAno?ano={releaseYear}
            [HttpGet("byAno")]
            public ActionResult<IEnumerable<Musica>> GetByAno([FromQuery] int ano)
            {
                var musicas = _context.Musicas
                    .Where(musica => musica.ReleaseDate.HasValue && musica.ReleaseDate.Value.Year == ano)
                    .Take(10)
                    .ToList();

                if (musicas.Count == 0)
                {
                    return NotFound("Não há musicas para recomendar com esse ano de lançamento.");
                }

                return Ok(musicas);
            }

            // get: api/recomendacao/byArtista?artista={artist}
            [HttpGet("byArtista")]
            public ActionResult<IEnumerable<Musica>> GetByArtista([FromQuery] string artista)
            {
                var musicas = _context.Musicas
                    .Where(musica => musica.Artist != null && musica.Artist.ToLower().Contains(artista.ToLower()))
                    .Take(10)
                    .ToList();

                if (musicas.Count == 0)
                {
                    return NotFound("Não há musicas para recomendar desse artista.");
                }

                return Ok(musicas);
            }
    }
}
