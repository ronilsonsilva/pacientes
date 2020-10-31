using Pacientes.Domain.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Pacientes.Domain.Shared.ViewModels
{
    public class PacienteViewModel : ViewModelBase
    {
        public string Nome { get; set; }
        public long CPF { get; set; }
        public long RG { get; set; }
        public int Cns { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string NomeMae { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public ICollection<TelefoneViewModel> Telefones { get; set; }
    }
}
