using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }

        public ICollection<PlaylistMusic> PlaylistMusics { get; set; } = new List<PlaylistMusic>();
    }
}
