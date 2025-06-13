using System.Collections.Generic;
using System.Linq;
using GestaoDeMusicas.DTO;
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

        // GET: api/playlist
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var playlists = await _context.Playlists
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.UserId,
                    PlaylistMusics = p.PlaylistMusics
                        .Select(pm => pm.MusicId)
                        .ToList()
                })
                .ToListAsync();

            return Ok(playlists);
        }

        // GET: api/playlist/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var playlist = await _context.Playlists
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.UserId,
                    PlaylistMusics = p.PlaylistMusics
                        .Select(pm => pm.MusicId)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (playlist == null)
                return NotFound();

            return Ok(playlist);
        }

        // GET: api/playlist/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var playlists = await _context.Playlists
                .Where(p => p.UserId == userId)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.UserId,
                    PlaylistMusics = p.PlaylistMusics
                        .Select(pm => pm.MusicId)
                        .ToList()
                })
                .ToListAsync();

            return Ok(playlists);
        }

        // POST: api/playlist/user/{userId}
        [HttpPost("user/{userId}")]
        public async Task<IActionResult> PostPlaylist(int userId, [FromBody] CreatePlaylistDto dto)
        {
            if (!dto.UserId.HasValue || dto.UserId.Value != userId)
                return BadRequest("UserId da URL não bate com o corpo.");

            var playlist = new Playlist
            {
                Name = dto.Name,
                Description = dto.Description,
                UserId = dto.UserId.Value
            };

            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = playlist.Id }, new
            {
                playlist.Id,
                playlist.Name,
                playlist.Description,
                playlist.UserId,
                PlaylistMusics = new List<int>()
            });
        }

        // POST: api/playlist/{playlistId}/add-music/{musicId}
        [HttpPost("{playlistId}/add-music/{musicId}")]
        public async Task<IActionResult> AddMusic(int playlistId, int musicId)
        {
            var playlist = await _context.Playlists.FindAsync(playlistId);
            if (playlist == null)
                return NotFound($"Playlist {playlistId} não encontrada.");

            var music = await _context.Musics.FindAsync(musicId);
            if (music == null)
                return NotFound($"Música {musicId} não encontrada.");

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

            return Ok(new { playlistId, musicId });
        }

        // DELETE: api/playlist/{playlistId}/remove-music/{musicId}
        [HttpDelete("{playlistId}/remove-music/{musicId}")]
        public async Task<IActionResult> RemoveMusic(int playlistId, int musicId)
        {
            var item = await _context.PlaylistMusics
                .FirstOrDefaultAsync(pm => pm.PlaylistId == playlistId && pm.MusicId == musicId);

            if (item == null)
                return NotFound();

            _context.PlaylistMusics.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
