using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao_e_Gestao_do_Usuario.Models
{
    [Table("Status")]
    //Add-Migration M01-AddTableStatus
    //update-database

    public class Status
    {
        [Key]
        [Required(ErrorMessage = "O campo de id é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de descrição é obrigatório!")]
        public string Descricao { get; set; }

        //Definidos pela API
        [Required(ErrorMessage = "O campo de data de criação é obrigatório!")]
        public DateTime Criado_Em { get; set; }

        public DateTime Alterado_Em { get; set; }

    }
}