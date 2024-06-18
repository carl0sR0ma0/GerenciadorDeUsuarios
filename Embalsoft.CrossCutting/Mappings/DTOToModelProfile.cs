using AutoMapper;
using Embalsoft.Domain.DTO.Grupo;
using Embalsoft.Domain.DTO.Usuario;
using Embalsoft.Domain.Models;

namespace Embalsoft.CrossCutting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<UsuarioDTO, UsuarioModel>().ReverseMap();
            CreateMap<AdicionarUsuarioDTO, UsuarioModel>().ReverseMap();
            CreateMap<AlterarUsuarioDTO, UsuarioModel>().ReverseMap();

            CreateMap<GrupoDTO, GrupoModel>().ReverseMap();
            CreateMap<AdicionarGrupoDTO, GrupoModel>().ReverseMap();
            CreateMap<AlterarGrupoDTO, GrupoModel>().ReverseMap();
        }
    }
}
