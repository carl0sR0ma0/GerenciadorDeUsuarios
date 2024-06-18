using AutoMapper;
using Embalsoft.Domain.DTO.Usuario;
using Embalsoft.Domain.Entities;
using Embalsoft.Domain.Interfaces.Repository;
using Embalsoft.Domain.Interfaces.Services;
using Embalsoft.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Embalsoft.Services
{
    public class UsuarioService(IUsuarioRepository _repository, IMapper _mapper) : IUsuarioService
    {
        public async Task<ResultadoAlterarUsuarioDTO?> Alterar(AlterarUsuarioDTO usuario)
        {
            var model = _mapper.Map<UsuarioModel>(usuario);
            var entity = _mapper.Map<UsuarioEntity>(model);
            
            if (!string.IsNullOrEmpty(usuario.Senha))
                entity.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            
            var result = await _repository.Alterar(entity);

            return _mapper.Map<ResultadoAlterarUsuarioDTO>(result);
        }

        public async Task<bool> Deletar(int id)
        {
            return await _repository.Deletar(id);
        }
        
        public async Task<UsuarioDTO?> ObterPorId(int id)
        {
            var entity = await _repository.ObterPorId(id);
            return _mapper.Map<UsuarioDTO>(entity) ?? null;
        }

        public async Task<IEnumerable<UsuarioDTO>?> ObterTodos()
        {
            var listEntity = await _repository.ObterTodos();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(listEntity);
        }

        public async Task<ResultadoAdicionarUsuarioDTO?> Publicar(AdicionarUsuarioDTO usuario)
        {
            var model = _mapper.Map<UsuarioModel>(usuario);
            var entity = _mapper.Map<UsuarioEntity>(model);

            entity.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            var result = await _repository.Adicionar(entity);
            return _mapper.Map<ResultadoAdicionarUsuarioDTO>(result);
        }

        public async Task<object?> Login(LoginDTO login, IConfiguration _configuration)
        {
            var user = await _repository.BuscarPorLogin(login.Nome);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Senha, user.Senha))
                return null;

            var group = await _repository.GrupoAdministrador(user.GrupoId);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Nome),
                new Claim("id", user.Id.ToString()),
                new Claim("role", group ? "Administrador" : "Usuario")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new { token = tokenString };
        }
    }
}
