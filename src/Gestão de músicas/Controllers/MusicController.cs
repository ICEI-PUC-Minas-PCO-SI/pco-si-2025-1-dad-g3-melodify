using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly MusicService _musicService;

        public MusicController(AppDbContext context, MusicService musicService)
        {
            _context = context;
            _musicService = musicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var musics = await _context.Musics.ToListAsync();
            return Ok(musics);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string q)
        {
            var music = await _musicService.SearchOrAddMusicAsync(q);
            return music == null ? NotFound() : Ok(music);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var music = await _context.Musics.FindAsync(id);
            return music == null ? NotFound() : Ok(music);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var music = await _context.Musics.FindAsync(id);
            if (music == null)
                return NotFound();

            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Music updated)
        {
            var music = await _context.Musics.FindAsync(id);
            if (music == null)
                return NotFound();

            music.Title = updated.Title;
            music.Artist = updated.Artist;
            music.Album = updated.Album;
            music.Genre = updated.Genre;
            music.ReleaseDate = updated.ReleaseDate;
            music.Duration = updated.Duration;
            music.CoverUrl = updated.CoverUrl;

            await _context.SaveChangesAsync();
            return Ok(music);
        }

        [HttpPost("add-by-spotify-id/{spotifyId}")]
        public async Task<IActionResult> AddBySpotifyId(string spotifyId)
        {
            var music = await _musicService.AddMusicBySpotifyIdAsync(spotifyId);
            return music == null ? Conflict("Música já existe no banco.") : Ok(music);
        }

        [HttpPost("add-multiple-by-spotify-id")]
        public async Task<IActionResult> AddMultipleBySpotifyIds([FromBody] List<string> spotifyIds)
        {
            if (spotifyIds == null || !spotifyIds.Any())
                return BadRequest("A lista de IDs não pode estar vazia.");

            var added = await _musicService.AddMultipleBySpotifyIdsAsync(spotifyIds);
            return Ok(new
            {
                count = added.Count,
                added
            });
        }
    }
}
