using Clientes.Shared.Dtos;
using Clientes.Shared.ValueObject;

namespace Clientes.Application.Contracts
{
    public interface ICidadeApplication
    {
        Task<IList<CidadeDto>> GetCidades(EstadoEnum estado);
    }
}
