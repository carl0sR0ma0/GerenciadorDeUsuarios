﻿namespace Embalsoft.Domain.DTO.Usuario
{
    public class UsuarioLogadoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public int GrupoId { get; set; }
    }
}
