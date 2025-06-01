namespace WebApplication1.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string? Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
    }
}
