using Embalsoft.Domain.DTO.Usuario;
using Microsoft.Extensions.Configuration;

namespace Embalsoft.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO?> ObterPorId(int id);
        Task<IEnumerable<UsuarioDTO>?> ObterTodos();
        Task<ResultadoAdicionarUsuarioDTO?> Publicar(AdicionarUsuarioDTO usuario);
        Task<ResultadoAlterarUsuarioDTO?> Alterar(AlterarUsuarioDTO usuario);
        Task<bool> Deletar(int id);
        Task<object?> Login(LoginDTO login, IConfiguration _configuration);
    }
}
