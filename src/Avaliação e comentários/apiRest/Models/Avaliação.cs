using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiRest.Models
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Usuario { get; set; } // FK para Usuario

        [Required]
        public string Musica { get; set; }

        public DateTime Hora { get; set; } = DateTime.Now;

        public string Texto { get; set; }

    
        public ICollection<Comentario> Comentarios { get; set; }
    }
}
