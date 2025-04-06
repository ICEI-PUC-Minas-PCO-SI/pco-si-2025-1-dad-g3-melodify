using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao_e_Gestao_do_Usuario.Models
{
    [Table("Senhas")]
    //Add-Migration M01-AddTableSenhas
    //update-database

    public class Senha
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Id da senha é obrigatório!")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "Definir a senha é obrigatório!")]
        public DateTime Criacao { get; set; }

    }
}
