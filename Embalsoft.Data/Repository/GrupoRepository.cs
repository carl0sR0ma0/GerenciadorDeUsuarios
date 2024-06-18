using Embalsoft.API.Repository;
using Embalsoft.Domain.Entities;
using Embalsoft.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Embalsoft.Data.Repository
{
    public class GrupoRepository : BaseRepository<GrupoEntity>, IGrupoRepository
    {
        private readonly DbSet<GrupoEntity> _dataset;

        public GrupoRepository(EmbalsoftContext context) : base(context)
        {
            _dataset = _context.Set<GrupoEntity>();
        }

        public async Task<IEnumerable<GrupoEntity?>> ObterTodos()
        {
            return await _dataset.Include(g => g.Usuarios).ToListAsync();
        }
    }
}
