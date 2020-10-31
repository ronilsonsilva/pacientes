using Pacientes.Domain.Shared;
using Pacientes.Domain.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Pacientes.Domain.Entities
{
    public class Paciente : EntityBase
    {
        protected Paciente() { }

        public Paciente(string nome, long cpf, long rg, int cns, DateTime dataNascimento, Sexo sexo, string nomeMae, string endereco, string bairro, int cep, string estado, string cidade)
        {
            Nome = nome;
            CPF = cpf;
            RG = rg;
            Cns = cns;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            NomeMae = nomeMae;
            Endereco = endereco;
            Bairro = bairro;
            Cep = cep;
            Estado = estado;
            Cidade = cidade;
        }
        
        public Paciente(long id, string nome, long cpf, long rg, int cns, DateTime dataNascimento, Sexo sexo, string nomeMae, string endereco, string bairro, int cep, string estado, string cidade)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            RG = rg;
            Cns = cns;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            NomeMae = nomeMae;
            Endereco = endereco;
            Bairro = bairro;
            Cep = cep;
            Estado = estado;
            Cidade = cidade;
        }

        public string Nome { get; set; }
        public long CPF { get; set; }
        public long RG { get; set; }
        public long Cns { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string NomeMae { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public ICollection<Telefone> Telefones { get; set; }

        public override bool IsValid()
        {
            var validator = new PacienteValidators();
            this.Validators = validator.Validate(this);
            return this.Validators.IsValid;
        }
    }
}
