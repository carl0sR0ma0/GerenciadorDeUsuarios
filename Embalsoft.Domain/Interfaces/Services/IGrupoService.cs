using Embalsoft.Domain.DTO.Grupo;

namespace Embalsoft.Domain.Interfaces.Services
{
    public interface IGrupoService
    {
        Task<GrupoCompletoDTO?> ObterPorId(int id);
        Task<IEnumerable<GrupoCompletoDTO?>> ObterTodos();
        Task<GrupoDTO> Publicar(AdicionarGrupoDTO grupo);
        Task<GrupoDTO?> Alterar(AlterarGrupoDTO grupo);
        Task<bool> Deletar(int id);
    }
}
