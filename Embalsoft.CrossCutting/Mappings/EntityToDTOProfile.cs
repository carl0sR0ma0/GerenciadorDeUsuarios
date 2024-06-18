using AutoMapper;
using Embalsoft.Domain.DTO.Grupo;
using Embalsoft.Domain.DTO.Usuario;
using Embalsoft.Domain.Entities;

namespace Embalsoft.CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UsuarioEntity, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioEntity, ResultadoAdicionarUsuarioDTO>().ReverseMap();
            CreateMap<UsuarioEntity, ResultadoAlterarUsuarioDTO>().ReverseMap();

            CreateMap<UsuarioEntity, UsuarioLogadoDTO>().ReverseMap();

            CreateMap<GrupoEntity, GrupoDTO>().ReverseMap();
            CreateMap<GrupoEntity, GrupoCompletoDTO>().ReverseMap();
        }
    }
}
