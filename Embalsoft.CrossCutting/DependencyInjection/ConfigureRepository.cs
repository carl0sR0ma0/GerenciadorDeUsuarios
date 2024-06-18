using Embalsoft.API.Repository;
using Embalsoft.Data.Repository;
using Embalsoft.Domain.Entities;
using Embalsoft.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Embalsoft.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
            serviceCollection.AddScoped<IGrupoRepository, GrupoRepository>();

            serviceCollection.AddDbContext<EmbalsoftContext>(options =>
            options.UseInMemoryDatabase("UserManagement"));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<EmbalsoftContext>();
            InitializeDatabase(context);
        }

        protected static void InitializeDatabase(EmbalsoftContext context)
        {
            var adminGroup = new GrupoEntity
            {
                Id = 1,
                Descricao = "ADMINISTRADOR",
                Administrador = true,
                DataCadastro = DateTime.UtcNow,
                DataAlterado = DateTime.UtcNow
            };
            context.Grupos.Add(adminGroup);

            var adminUser = new UsuarioEntity
            {
                Id = 1,
                Nome = "ADMIN",
                Senha = BCrypt.Net.BCrypt.HashPassword("ADMIN"),
                CPF = "000.000.000-00",
                GrupoId = 1,
                DataCadastro = DateTime.UtcNow,
                DataAlterado = DateTime.UtcNow
            };
            context.Usuarios.Add(adminUser);

            context.SaveChanges();
        }
    }
}
