using Pacientes.Domain.Shared.Enums;

namespace Pacientes.Domain.Shared.ViewModels
{
    public class TelefoneViewModel : ViewModelBase
    {
        public TipoTelefone Tipo { get; set; }
        public int DDD { get; set; }
        public long Numero { get; set; }
        public long PacienteId { get; set; }
        public string TipoDescricao
        {
            get
            {
                switch (this.Tipo)
                {
                    case TipoTelefone.CELULAR:
                        return "Celular";
                    case TipoTelefone.COMERCIAL:
                        return "Comercial";
                    case TipoTelefone.RESIDENCIAL:
                        return "Residencial";
                    default: return string.Empty;
                }
            }
        }
    }
}
