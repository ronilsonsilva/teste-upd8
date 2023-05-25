using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Shared;
using Clientes.Shared.ValueObject;
using MediatR;

namespace Clientes.Domain.ClienteAgregate.Commands
{
    public class CreateClienteCommand : IRequest<Response<Cliente>>
    {
        public CreateClienteCommand()
        {
            
        }

        public CreateClienteCommand(string nome, string cpf, DateTime dataNascimento, SexoEnum sexo, string endereco, int codigoCidade, EstadoEnum estado)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Endereco = endereco;
            CodigoCidade = codigoCidade;
            Estado = estado;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public string Endereco { get; set; }
        public int CodigoCidade { get; set; }
        public EstadoEnum Estado { get; set; }
    }
}
