using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Shared.ValueObject;

namespace Clientes.Domain.Contracts
{
    public interface ICidadeRepository
    {
        Task<IList<Cidade>> Get();
        Task<IList<Cidade>> Get(EstadoEnum estado);
        Task<Cidade> Get(int codigoIbge);
    }
}
