using System.ComponentModel.DataAnnotations;

namespace Autenticacao_e_Gestao_do_Usuario.Models.DTO
{
    public class CadastroDto
    {
        [Required(ErrorMessage = "O campo de nome do usuário é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [RegularExpression("^(Usuario|Administrador)$", ErrorMessage = "Perfil deve ser 'Usuario' ou 'Administrador'.")]
        public string Perfil { get; set; }

    }
}
