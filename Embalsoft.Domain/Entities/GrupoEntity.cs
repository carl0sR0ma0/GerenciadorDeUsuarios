using Newtonsoft.Json;

namespace Embalsoft.Domain.Entities
{
    public class GrupoEntity : BaseEntity
    {
        public string Descricao { get; set; } = string.Empty;
        public bool Administrador { get; set; }

        [JsonIgnore]
        public IEnumerable<UsuarioEntity>? Usuarios { get; set; }
    }
}
