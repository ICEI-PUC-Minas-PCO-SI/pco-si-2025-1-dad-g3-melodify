using System.ComponentModel.DataAnnotations;

namespace Autenticacao_e_Gestao_do_Usuario.Models.DTO
{
    public class SaidaUsuarioDto
    {

        [Key]
        [Required(ErrorMessage = "O campo de id é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome do usuário é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [RegularExpression("^(Usuario|Administrador)$", ErrorMessage = "Perfil deve ser 'Usuario' ou 'Administrador'.")]
        public string Perfil { get; set; }

        //Definidos pela API
        public int Status { get; set; }

        [Required(ErrorMessage = "O campo de data de criação é obrigatório!")]
        public DateTime Criado_Em { get; set; }

        public DateTime Alterado_Em { get; set; }

    }
}
