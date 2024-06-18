using Embalsoft.Domain.DTO.Usuario;
using Embalsoft.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Embalsoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService _service, IConfiguration _configuration) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ObterUsuarios()
        {
            return Ok(await _service.ObterTodos());
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CriarUsuario([FromBody] AdicionarUsuarioDTO usuario)
        {
            return Ok(await _service.Publicar(usuario));
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] AlterarUsuarioDTO usuario)
        {
            return Ok(await _service.Alterar(usuario));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            return Ok(await _service.Deletar(id));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var result = await _service.Login(login, _configuration);
            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
    }
}
