namespace Embalsoft.Domain.Models
{
    public class GrupoModel : BaseModel
    {
        private string _descricao = string.Empty;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private bool _administrador;
        public bool Administrador
        {
            get { return _administrador; }
            set { _administrador = value; }
        }
    }
}
