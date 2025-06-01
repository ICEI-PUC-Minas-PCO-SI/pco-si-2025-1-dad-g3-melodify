using System.Text.Json;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class MusicService
    {
        private readonly SpotifyService _spotifyService;
        private readonly AppDbContext _context;

        public MusicService(SpotifyService spotifyService, AppDbContext context)
        {
            _spotifyService = spotifyService;
            _context = context;
        }

        public async Task<Music?> SearchOrAddMusicAsync(string query)
        {
            var existing = await _context.Musics
                .FirstOrDefaultAsync(m => m.Title.Contains(query));

            if (existing != null)
                return existing;

            var spotifyJson = await _spotifyService.SearchTrackAsync(query);
            var music = ParseSpotifyTrack(spotifyJson);

            if (music != null)
            {
                _context.Musics.Add(music);
                await _context.SaveChangesAsync();
            }

            return music;
        }

        public async Task LoadInitialMusicBatchAsync(IEnumerable<string> queries)
        {
            foreach (var q in queries)
            {
                var exists = await _context.Musics.AnyAsync(m => m.Title.Contains(q));
                if (exists) continue;

                var spotifyJson = await _spotifyService.SearchTrackAsync(q);
                var music = ParseSpotifyTrack(spotifyJson);
                if (music != null)
                    _context.Musics.Add(music);
            }

            await _context.SaveChangesAsync();
        }

        private Music? ParseSpotifyTrack(string json)
        {
            var root = JsonDocument.Parse(json).RootElement;

            var first = root.GetProperty("tracks").GetProperty("items").EnumerateArray().FirstOrDefault();
            if (first.ValueKind == JsonValueKind.Undefined) return null;

            return new Music
            {
                SpotifyId = first.GetProperty("id").GetString(),
                Title = first.GetProperty("name").GetString(),
                Artist = first.GetProperty("artists")[0].GetProperty("name").GetString(),
                Album = first.GetProperty("album").GetProperty("name").GetString(),
                CoverUrl = first.GetProperty("album").GetProperty("images")[0].GetProperty("url").GetString(),
                Duration = TimeSpan.FromMilliseconds(first.GetProperty("duration_ms").GetInt32()),
                ReleaseDate = DateTime.TryParse(
                    first.GetProperty("album").GetProperty("release_date").GetString(), out var date)
                    ? date : null
            };
        }

        public async Task<Music?> AddMusicBySpotifyIdAsync(string spotifyId)
        {
            var exists = await _context.Musics.AnyAsync(m => m.SpotifyId == spotifyId);
            if (exists) return null;

            var json = await _spotifyService.GetTrackByIdAsync(spotifyId);
            var track = JsonDocument.Parse(json).RootElement;

            var music = new Music
            {
                SpotifyId = track.GetProperty("id").GetString(),
                Title = track.GetProperty("name").GetString(),
                Artist = track.GetProperty("artists")[0].GetProperty("name").GetString(),
                Album = track.GetProperty("album").GetProperty("name").GetString(),
                CoverUrl = track.GetProperty("album").GetProperty("images")[0].GetProperty("url").GetString(),
                Duration = TimeSpan.FromMilliseconds(track.GetProperty("duration_ms").GetInt32()),
                ReleaseDate = DateTime.TryParse(track.GetProperty("album").GetProperty("release_date").GetString(), out var date)
                    ? date : null
            };

            _context.Musics.Add(music);
            await _context.SaveChangesAsync();

            return music;
        }

        public async Task<List<Music>> AddMultipleBySpotifyIdsAsync(List<string> spotifyIds)
        {
            var added = new List<Music>();

            foreach (var id in spotifyIds.Distinct())
            {
                var exists = await _context.Musics.AnyAsync(m => m.SpotifyId == id);
                if (exists) continue;

                var json = await _spotifyService.GetTrackByIdAsync(id);
                var track = JsonDocument.Parse(json).RootElement;

                var music = new Music
                {
                    SpotifyId = track.GetProperty("id").GetString(),
                    Title = track.GetProperty("name").GetString(),
                    Artist = track.GetProperty("artists")[0].GetProperty("name").GetString(),
                    Album = track.GetProperty("album").GetProperty("name").GetString(),
                    CoverUrl = track.GetProperty("album").GetProperty("images")[0].GetProperty("url").GetString(),
                    Duration = TimeSpan.FromMilliseconds(track.GetProperty("duration_ms").GetInt32()),
                    ReleaseDate = DateTime.TryParse(track.GetProperty("album").GetProperty("release_date").GetString(), out var date)
                        ? date : null
                };

                _context.Musics.Add(music);
                added.Add(music);
            }

            await _context.SaveChangesAsync();
            return added;
        }
    }
}
