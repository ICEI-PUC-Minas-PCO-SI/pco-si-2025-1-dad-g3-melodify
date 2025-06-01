using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly SpotifyService _spotifyService;

        public SpotifyController(SpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTrack([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("A query 'q' é obrigatória.");

            var result = await _spotifyService.SearchTrackAsync(q);
            return Ok(result);
        }

        [HttpGet("music/{spotifyId}")]
        public async Task<IActionResult> GetTrackById(string spotifyId)
        {
            try
            {
                var json = await _spotifyService.GetTrackByIdAsync(spotifyId);
                return Ok(JsonDocument.Parse(json).RootElement);
            }
            catch (HttpRequestException)
            {
                return NotFound("Música não encontrada no Spotify.");
            }
        }
    }
}
