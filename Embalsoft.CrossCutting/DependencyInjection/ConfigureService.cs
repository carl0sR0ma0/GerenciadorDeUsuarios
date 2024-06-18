using Embalsoft.Domain.Interfaces.Services;
using Embalsoft.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Embalsoft.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<IUsuarioService, UsuarioService>();
            servicesCollection.AddTransient<IGrupoService, GrupoService>();
        }
    }
}
