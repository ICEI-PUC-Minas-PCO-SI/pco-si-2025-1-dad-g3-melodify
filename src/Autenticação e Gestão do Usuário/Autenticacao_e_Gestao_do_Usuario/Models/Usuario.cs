using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao_e_Gestao_do_Usuario.Models
{
    [Table("Usuarios")]
    //Add-Migration M01-AddTableUsuarios
    //update-database

    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Id do usuário é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public int Senha { get; set; }

    }
}
