using Microsoft.AspNetCore.Mvc;
using RecomendacaoDeMusicas.Data;
using RecomendacaoDeMusicas.Models;
using RecomendacaoDeMusicas.Services;

namespace RecomendacaoDeMusicas.Controllers
{
        [ApiController]
        [Route("api/[controller]")]

        public class RecomendacaoController : ControllerBase
        {
            private readonly IRecomendacaoService _service;

            public RecomendacaoController(IRecomendacaoService service)
            {
                _service = service;
            }

            // get: api/recomendacao/byGenero?genero={genre}
            [HttpGet("byGenero")]
            public ActionResult<IEnumerable<Musica>> GetByGenero([FromQuery] string genero)
            {
                var musicas = _service.GetByGenero(genero);

                if (!musicas.Any())
                {
                    return NotFound("Não há músicas para recomendar com esse gênero.");
                }

                return Ok(musicas);
            }

            // get: api/recomendacao/byAno?ano={releaseYear}
            [HttpGet("byAno")]
            public ActionResult<IEnumerable<Musica>> GetByAno([FromQuery] int ano)
            {
                var musicas = _service.GetByAno(ano);

                if (!musicas.Any())
                {
                    return NotFound("Não há musicas para recomendar com esse ano de lançamento.");
                }

                return Ok(musicas);
            }

            // get: api/recomendacao/byArtista?artista={artist}
            [HttpGet("byArtista")]
            public ActionResult<IEnumerable<Musica>> GetByArtista([FromQuery] string artista)
            {
                var musicas = _service.GetByArtista(artista);;

                if (!musicas.Any())
                {
                    return NotFound("Não há musicas para recomendar desse artista.");
                }

                return Ok(musicas);
            }
    }
}
