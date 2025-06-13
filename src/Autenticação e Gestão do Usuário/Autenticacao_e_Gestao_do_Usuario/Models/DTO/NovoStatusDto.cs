using System.ComponentModel.DataAnnotations;

namespace Autenticacao_e_Gestao_do_Usuario.Models.DTO
{
    public class NovoStatusDto
    {
        [Required(ErrorMessage = "O campo de descrição é obrigatório!")]
        public string Descricao { get; set; }
    }
}
