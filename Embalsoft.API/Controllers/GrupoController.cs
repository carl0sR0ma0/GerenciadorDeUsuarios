using Embalsoft.Domain.DTO.Grupo;
using Embalsoft.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Embalsoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController(IGrupoService _service) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ObterGrupos()
        {
            return Ok(await _service.ObterTodos());
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CriarGrupo([FromBody] AdicionarGrupoDTO grupo)
        {
            return Ok(await _service.Publicar(grupo));
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AtualizarGrupo([FromBody] AlterarGrupoDTO grupo)
        {
            var existingGroup = await _service.Alterar(grupo);
            if (existingGroup is null) return NotFound();
            return Ok(existingGroup);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeletarGrupo(int id)
        {
            return Ok(await _service.Deletar(id));
        }
    }
}
