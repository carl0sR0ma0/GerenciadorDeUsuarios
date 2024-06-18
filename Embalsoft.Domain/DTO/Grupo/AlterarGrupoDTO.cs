using System.ComponentModel.DataAnnotations;

namespace Embalsoft.Domain.DTO.Grupo
{
    public class AlterarGrupoDTO
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição é campo obrigatório")]
        [StringLength(100, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "Administrador é campo obrigatório")]
        public bool Administrador { get; set; }
    }
}
