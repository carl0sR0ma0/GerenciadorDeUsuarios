namespace Embalsoft.Domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;

        public int GrupoId { get; set; }
        public GrupoEntity? Grupo { get; set; }
    }
}
