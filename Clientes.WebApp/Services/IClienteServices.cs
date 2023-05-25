using Clientes.Shared;
using Clientes.Shared.Dtos;
using Clientes.Shared.FiltersModel;
using Clientes.Shared.InputModels;

namespace Clientes.WebApp.Services
{
    public interface IClienteServices
    {
        Task<IList<ListClienteDto>> GetList(ClienteFilters filters);
        Task<ClienteDto> GetById(int id);
        Task<Response<ClienteDto>> Create(CreateClienteInput input);
        Task<Response<ClienteDto>> Update(UpdateClienteInput input);
        Task<Response<bool>> Delete(int id);
    }
}
