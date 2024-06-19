using Embalsoft.API.Repository;
using Embalsoft.Domain.Entities;
using Embalsoft.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Embalsoft.Data.Repository
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        private readonly DbSet<UsuarioEntity> _dataset;

        public UsuarioRepository(EmbalsoftContext context) : base(context)
        {
            _dataset = _context.Set<UsuarioEntity>();
        }

        public async Task<UsuarioEntity?> BuscarPorLogin(string nome)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Nome.Equals(nome));
        }

        public async Task<IEnumerable<UsuarioEntity?>?> ObterTodos()
        {
            return await _context.Usuarios.Include(u => u.Grupo).ToListAsync();
        }

        public async Task<UsuarioEntity?> ObterPorId(int id)
        {
            return await _context.Usuarios.Include(u => u.Grupo).SingleOrDefaultAsync(e => e.Id.Equals(id));
        }
    }
}
