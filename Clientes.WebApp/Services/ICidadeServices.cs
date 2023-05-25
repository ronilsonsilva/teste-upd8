using Clientes.Shared.Dtos;
using Clientes.Shared.ValueObject;

namespace Clientes.WebApp.Services
{
    public interface ICidadeServices
    {
        IList<EstadoValueObject> GetEstados();
        Task<IList<CidadeDto>> GetCidades(EstadoEnum estado);
    }
}
