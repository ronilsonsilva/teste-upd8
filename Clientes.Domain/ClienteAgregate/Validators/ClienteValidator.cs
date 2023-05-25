using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Shared;
using Clientes.Shared.ValueObject;
using FluentValidation;

namespace Clientes.Domain.ClienteAgregate.Validators
{
    public class ClienteValidator : BaseValidator<Cliente>
    {
        public ClienteValidator() 
        { 
            RuleFor(x => x.Nome).MaximumLength(256).MinimumLength(2).NotEmpty().WithMessage("Nome deve ter entre 2 a 256 caracteres.");
            RuleFor(x => x.Endereco).MaximumLength(512).MinimumLength(2).NotEmpty().WithMessage("Endereço deve ter entre 2 a 512 caracteres.");
            RuleFor(x => x.Cpf).Must(IsCPF).WithMessage("CPF inválido.");
            RuleFor(x => x.DataNascimento).NotNull().NotEqual(DateTime.MinValue).WithMessage("Data de nascimento inválida.");
            RuleFor(x => x.CodigoCidade).NotNull().Must(value => value > 0).WithMessage("Cidade inválida.");
            RuleFor(x => x.Sexo).Must(value => Enum.IsDefined(typeof(SexoEnum), value)).WithMessage("Sexo inválido");
            RuleFor(x => x.Estado).Must(value => Enum.IsDefined(typeof(EstadoEnum), value)).WithMessage("Estado inválido");
        }
    }
}
