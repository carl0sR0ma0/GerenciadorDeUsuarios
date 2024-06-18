using AutoMapper;
using Embalsoft.CrossCutting.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Embalsoft.CrossCutting.OthersConfiguration
{
    public class ConfigureAutoMapper
    {
        public static void ConfigureDependenciesAutoMapper(IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DTOToModelProfile());
                cfg.AddProfile(new EntityToDTOProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
