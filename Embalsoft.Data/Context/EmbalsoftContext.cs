using Embalsoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Embalsoft.API.Repository
{
    public class EmbalsoftContext(DbContextOptions<EmbalsoftContext> options) : DbContext(options)
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<GrupoEntity> Grupos { get; set; }
    }
}
