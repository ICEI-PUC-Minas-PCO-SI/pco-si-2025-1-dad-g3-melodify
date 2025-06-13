using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class PlaylistMusic
    {
        public int Id { get; set; }

        public int PlaylistId { get; set; }
        [JsonIgnore]
        public int MusicId { get; set; }

        [JsonIgnore]
        public Playlist Playlist { get; set; }

        [JsonIgnore]
        public Music Music { get; set; }
    }
}
