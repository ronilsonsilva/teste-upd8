using Clientes.Shared;
using Clientes.Shared.Dtos;
using Clientes.Shared.FiltersModel;
using Clientes.Shared.InputModels;
using RestSharp;

namespace Clientes.WebApp.Services
{
    public class ClienteServices : IClienteServices
    {
        protected RestClient _restClient;

        public ClienteServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<Response<ClienteDto>> Create(CreateClienteInput input)
        {
            return await _restClient.PostJsonAsync<CreateClienteInput, Response<ClienteDto>>("cliente", input);
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await _restClient.DeleteAsync<Response<bool>>(new RestRequest($"cliente/{id}", Method.Delete));
        }

        public async Task<ClienteDto> GetById(int id)
        {
            return await _restClient.GetJsonAsync<ClienteDto>($"cliente/{id}");
        }

        public async Task<IList<ListClienteDto>> GetList(ClienteFilters filters)
        {
            return await _restClient.PostJsonAsync<ClienteFilters, ListClienteDto[]>("cliente/list", filters);
        }

        public async Task<Response<ClienteDto>> Update(UpdateClienteInput input)
        {
            return await _restClient.PutJsonAsync<UpdateClienteInput, Response<ClienteDto>>("cliente", input);
        }
    }
}
