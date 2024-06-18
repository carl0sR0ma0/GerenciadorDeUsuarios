namespace Embalsoft.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        private DateTime _dataCadastro;
        public DateTime DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime DataAlterado { get; set; }
    }
}
