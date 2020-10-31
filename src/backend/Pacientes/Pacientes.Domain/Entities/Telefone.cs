using Pacientes.Domain.Shared;
using Pacientes.Domain.Shared.Enums;
using System;

namespace Pacientes.Domain.Entities
{
    public class Telefone : EntityBase
    {
        protected Telefone() {}
        public Telefone(TipoTelefone tipo, int ddd, long numero, int pacienteId)
        {
            Tipo = tipo;
            DDD = ddd;
            Numero = numero;
            PacienteId = pacienteId;
        }
        
        public Telefone(long id, TipoTelefone tipo, int ddd, long numero, int pacienteId)
        {
            Id = id;
            Tipo = tipo;
            DDD = ddd;
            Numero = numero;
            PacienteId = pacienteId;
        }

        public TipoTelefone Tipo { get; protected set; }
        public int DDD { get; protected set; }
        public long Numero { get; protected set; }
        public long PacienteId { get; protected set; }
        public Paciente Paciente { get; set; }

        public override bool IsValid()
        {
            var validator = new TelefoneValidators();
            this.Validators = validator.Validate(this);
            return this.Validators.IsValid;
        }
    }
}
