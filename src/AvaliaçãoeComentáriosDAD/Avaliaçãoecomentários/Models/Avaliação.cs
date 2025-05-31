using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Avaliaçãoecomentários.Models
{
    [Table("Avaliacoes")]
    public class Avaliação
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Usuario { get; set; }

        [Required]
        public string Musica { get; set; }

        public DateTime Hora { get; set; } = DateTime.Now;

        [Required]
        [StringLength(200)]
        public string Texto { get; set; }

        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
