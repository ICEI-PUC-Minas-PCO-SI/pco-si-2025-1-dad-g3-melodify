using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Avaliaçãoecomentários.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Usuario { get; set; }

        [Required]
        public int AvaliacaoId { get; set; }

        public DateTime Hora { get; set; } = DateTime.Now;

        [Required]
        public string Texto { get; set; }

       
        [ForeignKey("AvaliacaoId")]
        [JsonIgnore]
        public Avaliação? Avaliacao { get; set; }

    }
}
