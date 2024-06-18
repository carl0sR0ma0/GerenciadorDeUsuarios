namespace Embalsoft.Domain.Models
{
    public class BaseModel
    {
		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private DateTime _dataCadastro;

		public DateTime DataCadastro
        {
			get { return _dataCadastro; }
			set { _dataCadastro = value == null ? DateTime.UtcNow : value; }
		}

		private DateTime _dataAlterado;

		public DateTime DataAlterado
        {
			get { return _dataAlterado; }
			set { _dataAlterado = value; }
		}

	}
}
