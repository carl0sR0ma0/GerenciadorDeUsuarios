using Embalsoft.Domain.DTO.Usuario;

namespace Embalsoft.Domain.DTO.Grupo
{
    public class GrupoCompletoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Administrador { get; set; }
        public IEnumerable<UsuarioDTO>? Usuarios { get; set; }
    }
}
