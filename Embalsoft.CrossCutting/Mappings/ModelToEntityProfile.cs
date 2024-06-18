using AutoMapper;
using Embalsoft.Domain.Entities;
using Embalsoft.Domain.Models;

namespace Embalsoft.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UsuarioModel, UsuarioEntity>().ReverseMap();
            CreateMap<GrupoModel, GrupoEntity>().ReverseMap();
        }
    }
}
