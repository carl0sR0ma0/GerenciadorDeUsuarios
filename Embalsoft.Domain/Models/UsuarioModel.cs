namespace Embalsoft.Domain.Models
{
    public class UsuarioModel : BaseModel
    {
		private string _nome = string.Empty;
		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private string _senha = string.Empty;
        public string Senha
		{
			get { return _senha; }
			set { _senha = value; }
		}

		private string _cpf = string.Empty;
        public string CPF
		{
			get { return _cpf; }
			set { _cpf = value; }
		}

		private int _GrupoId;
		public int GrupoId
		{
			get { return _GrupoId; }
			set { _GrupoId = value; }
		}
	}
}
