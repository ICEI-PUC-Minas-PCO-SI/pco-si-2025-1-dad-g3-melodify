using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiRest.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Usuario { get; set; } // FK para Usuario

        [Required]
        public int Id_Avaliacao { get; set; } // FK para Avaliacao

        public DateTime Hora { get; set; } = DateTime.Now;

        public string Texto { get; set; }

        // Relacionamento com Avaliacao (FK)
        [ForeignKey("Id_Avaliacao")]
        public Avaliacao Avaliacao { get; set; }
    }
}
