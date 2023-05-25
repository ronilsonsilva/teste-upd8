using Clientes.Shared.ValueObject;

namespace Clientes.Shared.FiltersModel
{
    public record ClienteFilters(string? Nome, string? Cpf, DateTime? DataNascimento, SexoEnum? Sexo, int? CodigoCidade, EstadoEnum? Estado);
}
