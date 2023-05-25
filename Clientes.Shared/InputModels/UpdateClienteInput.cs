using Clientes.Shared.ValueObject;

namespace Clientes.Shared.InputModels
{
    public record UpdateClienteInput(int Id, string Nome, string Cpf, DateTime DataNascimento, SexoEnum Sexo, string Endereco, int CodigoCidade, EstadoEnum Estado);
}
