using Embalsoft.Domain.Entities;

namespace Embalsoft.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<UsuarioEntity>
    {
        Task<UsuarioEntity?> BuscarPorLogin(string nome);
        Task<IEnumerable<UsuarioEntity?>?> ObterTodos();
        Task<UsuarioEntity?> ObterPorId(int id);
    }
}
