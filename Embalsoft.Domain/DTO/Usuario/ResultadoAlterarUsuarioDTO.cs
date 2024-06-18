using Embalsoft.Domain.DTO.Grupo;

namespace Embalsoft.Domain.DTO.Usuario
{
    public class ResultadoAlterarUsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public int GrupoId { get; set; }
        public GrupoDTO? Grupo { get; set; }
        public DateTime DataAlterado { get; set; }
    }
}
