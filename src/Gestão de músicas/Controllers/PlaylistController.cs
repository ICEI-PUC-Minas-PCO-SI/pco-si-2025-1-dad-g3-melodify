using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlaylistController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var playlists = await _context.Playlists
                .Include(p => p.PlaylistMusics)
                    .ThenInclude(pm => pm.Music)
                .ToListAsync();

            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var playlist = await _context.Playlists
                .Include(p => p.PlaylistMusics)
                    .ThenInclude(pm => pm.Music)
                .FirstOrDefaultAsync(p => p.Id == id);

            return playlist == null ? NotFound() : Ok(playlist);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var playlists = await _context.Playlists
                .Where(p => p.UserId == userId)
                .Include(p => p.PlaylistMusics)
                    .ThenInclude(pm => pm.Music)
                .ToListAsync();

            return Ok(playlists);
        }

        [HttpPost("user/{userId}")]
        public async Task<IActionResult> CreateForUser(int userId, [FromBody] Playlist playlist)
        {
            playlist.UserId = userId;

            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = playlist.Id }, playlist);
        }

        [HttpPost("{playlistId}/add-music/{musicId}")]
        public async Task<IActionResult> AddMusic(int playlistId, int musicId)
        {
            var exists = await _context.PlaylistMusics
                .AnyAsync(pm => pm.PlaylistId == playlistId && pm.MusicId == musicId);

            if (exists)
                return BadRequest("Música já está na playlist.");

            _context.PlaylistMusics.Add(new PlaylistMusic
            {
                PlaylistId = playlistId,
                MusicId = musicId
            });

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{playlistId}/remove-music/{musicId}")]
        public async Task<IActionResult> RemoveMusic(int playlistId, int musicId)
        {
            var item = await _context.PlaylistMusics
                .FirstOrDefaultAsync(pm => pm.PlaylistId == playlistId && pm.MusicId == musicId);

            if (item == null) return NotFound();

            _context.PlaylistMusics.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
