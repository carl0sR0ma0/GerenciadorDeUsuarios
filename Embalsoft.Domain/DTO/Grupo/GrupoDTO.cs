namespace Embalsoft.Domain.DTO.Grupo
{
    public class GrupoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Administrador { get; set; }
    }
}
