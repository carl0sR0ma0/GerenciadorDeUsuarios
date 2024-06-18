using System.ComponentModel.DataAnnotations;

namespace Embalsoft.Domain.DTO.Usuario
{
    public class AdicionarUsuarioDTO
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Senha é campo obrigatório")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "CPF é campo obrigatório")]
        [StringLength(14, ErrorMessage = "CPF deve ter no máximo {1} caracteres.")]
        public string CPF { get; set; } = string.Empty;
        [Required(ErrorMessage = "Id do grupo é campo obrigatório")]
        public int GrupoId { get; set; }
    }
}
