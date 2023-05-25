using Clientes.Domain.ClienteAgregate.Validators;
using Clientes.Shared;
using Clientes.Shared.ValueObject;
using FluentValidation.Results;

namespace Clientes.Domain.ClienteAgregate.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string cpf, DateTime dataNascimento, SexoEnum sexo, string endereco, int codigoCidade, EstadoEnum estado)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Endereco = endereco;
            CodigoCidade = codigoCidade;
            Estado = estado;
        }

        protected Cliente() { }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public SexoEnum Sexo { get; private set; }
        public string Endereco { get; private set; }
        public int CodigoCidade { get; private set; }
        public EstadoEnum Estado { get; private set; }

        public Cidade Cidade { get; set; }

        public override ValidationResult Validate()
        {
            return new ClienteValidator().Validate(this);
        }
    }
}
