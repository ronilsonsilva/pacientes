using FluentValidation.Results;
using System;

namespace Pacientes.Domain.Shared
{
    public abstract class EntityBase
    {
        public long Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public ValidationResult Validators { get; protected set; }

        public abstract bool IsValid();
    }
}
