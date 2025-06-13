using System.ComponentModel.DataAnnotations;

namespace GestaoDeMusicas.DTO
{
    public class AddMusicDto
    {
        public int? PlaylistId { get; set; }
        [Required]
        public int MusicId { get; set; }
    }
}
