﻿using Embalsoft.Domain.DTO.Grupo;

namespace Embalsoft.Domain.DTO.Usuario
{
    public class ResultadoAdicionarUsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public GrupoDTO? Grupo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
