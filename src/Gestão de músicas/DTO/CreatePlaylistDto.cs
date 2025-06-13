using System.ComponentModel.DataAnnotations;

namespace GestaoDeMusicas.DTO
{
    public class CreatePlaylistDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // opcional: atribuir dono
        public int? UserId { get; set; }
    }
}
