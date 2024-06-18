using Embalsoft.API.Repository;
using Embalsoft.Domain.Entities;
using Embalsoft.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Embalsoft.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EmbalsoftContext _context;
        private readonly DbSet<T> _dataset;

        public BaseRepository(EmbalsoftContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T?> Adicionar(T entity)
        {
            try
            {
                entity.DataCadastro = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
                entity.DataAlterado = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<T?> Alterar(T entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id));
                if (result is null) return null;

                entity.DataAlterado = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
                entity.DataCadastro = result.DataCadastro;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<bool> Deletar(int id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(e => e.Id.Equals(id));
                if (result is null) return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<bool> GrupoAdministrador(int id)
        {
            var result = await _context.Set<GrupoEntity>().FirstOrDefaultAsync(e => e.Id == id);
            return result!.Administrador;
        }

        public async Task<T?> ObterPorId(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(e => e.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
