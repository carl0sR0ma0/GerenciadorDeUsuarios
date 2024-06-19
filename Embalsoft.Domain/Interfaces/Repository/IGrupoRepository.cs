using Embalsoft.Domain.Entities;

namespace Embalsoft.Domain.Interfaces.Repository
{
    public interface IGrupoRepository : IRepository<GrupoEntity>
    {
        Task<IEnumerable<GrupoEntity?>> ObterTodos();
        Task<GrupoEntity?> ObterPorId(int id);
    }
}
