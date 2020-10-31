using System;

namespace Pacientes.Domain.Shared
{
    public class ViewModelBase
    {
        public long? Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
