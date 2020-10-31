using FluentValidation;

namespace Pacientes.Domain.Entities
{
    public class TelefoneValidators : AbstractValidator<Telefone>
    {
        public TelefoneValidators()
        {
            RuleFor(x => x.DDD)
                .NotEmpty().WithMessage("DDD deve ser preenchido")
                .NotNull().WithMessage("DDD deve ser preenchido")
                .NotEqual(0).WithMessage("DDD inválido");
            
            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Numero deve ser preenchido")
                .NotNull().WithMessage("Numero deve ser preenchido")
                .NotEqual(0).WithMessage("Numero inválido");
            
            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("Tipo deve ser preenchido")
                .NotNull().WithMessage("Tipo deve ser preenchido");
        }
    }
}
