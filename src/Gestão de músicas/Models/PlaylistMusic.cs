namespace WebApplication1.Models
{
    public class PlaylistMusic
    {
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public int MusicId { get; set; }
        public Music Music { get; set; }
    }
}
