using AutoMapper;
using Embalsoft.Domain.DTO.Grupo;
using Embalsoft.Domain.Entities;
using Embalsoft.Domain.Interfaces.Repository;
using Embalsoft.Domain.Interfaces.Services;
using Embalsoft.Domain.Models;

namespace Embalsoft.Services
{
    public class GrupoService(IGrupoRepository _repository, IMapper _mapper) : IGrupoService
    {
        public async Task<GrupoDTO?> Alterar(AlterarGrupoDTO grupo)
        {
            var model = _mapper.Map<GrupoModel>(grupo);
            var entity = _mapper.Map<GrupoEntity>(model);
            var result = await _repository.Alterar(entity);

            return _mapper.Map<GrupoDTO>(result);
        }

        public async Task<bool> Deletar(int id)
        {
            return await _repository.Deletar(id);
        }

        public async Task<GrupoCompletoDTO?> ObterPorId(int id)
        {
            var entity = await _repository.ObterPorId(id);
            return _mapper.Map<GrupoCompletoDTO>(entity) ?? null;
        }

        public async Task<IEnumerable<GrupoCompletoDTO?>> ObterTodos()
        {
            var listEntity = await _repository.ObterTodos();
            return _mapper.Map<IEnumerable<GrupoCompletoDTO>>(listEntity);
        }

        public async Task<GrupoDTO> Publicar(AdicionarGrupoDTO grupo)
        {
            var model = _mapper.Map<GrupoModel>(grupo);
            var entity = _mapper.Map<GrupoEntity>(model);

            var result = await _repository.Adicionar(entity);
            
            return _mapper.Map<GrupoDTO>(result);
        }
    }
}
