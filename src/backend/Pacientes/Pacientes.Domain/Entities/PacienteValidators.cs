using FluentValidation;

namespace Pacientes.Domain.Entities
{
    public class PacienteValidators : AbstractValidator<Paciente>
    {
        public PacienteValidators()
        {
            RuleFor(x => x.CPF)
                .NotNull().WithMessage("CPF deve ser preenchido")
                .Must(CPFValido).WithMessage("CPF inválido");

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome deve ser preenchido")
                .NotEmpty().WithMessage("Nome deve ser preenchido")
                .Length(4, 256).WithMessage("Nome deve ter entre 4 a 256 caracteres");
            
            RuleFor(x => x.Bairro)
                .NotNull().WithMessage("Bairro deve ser preenchido")
                .NotEmpty().WithMessage("Bairro deve ser preenchido")
                .Length(1, 256).WithMessage("Bairro deve ter entre 1 a 256 caracteres");
            
            RuleFor(x => x.Cidade)
                .NotNull().WithMessage("Cidade deve ser preenchido")
                .NotEmpty().WithMessage("Cidade deve ser preenchido")
                .Length(1, 256).WithMessage("Cidade deve ter entre 1 a 256 caracteres");
            
            RuleFor(x => x.Endereco)
                .NotNull().WithMessage("Endereco deve ser preenchido")
                .NotEmpty().WithMessage("Endereco deve ser preenchido")
                .Length(1, 512).WithMessage("Endereco deve ter entre 1 a 256 caracteres");

            RuleFor(x => x.NomeMae)
                .MaximumLength(256).WithMessage("NomeMae deve ter no  máximo 256 caracteres");

            RuleFor(x => x.RG)
                .NotNull().WithMessage("RG deve ser preenchido")
                .NotEmpty().WithMessage("RG deve ser preenchido");
        }

        protected static bool CPFValido(long cpfNum)
        {
            string cpf = cpfNum.ToString();
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
