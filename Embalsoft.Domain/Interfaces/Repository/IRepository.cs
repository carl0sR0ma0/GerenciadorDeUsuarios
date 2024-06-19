using Embalsoft.Domain.Entities;

namespace Embalsoft.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> Adicionar(T entity);
        Task<T?> Alterar(T entity);
        Task<bool> Deletar(int id);
        Task<bool> GrupoAdministrador(int id);
    }
}
