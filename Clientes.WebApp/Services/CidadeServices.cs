using Clientes.Shared.Dtos;
using Clientes.Shared.ValueObject;
using RestSharp;

namespace Clientes.WebApp.Services
{
    internal class CidadeServices : ICidadeServices
    {
        private RestClient _restClient;

        public CidadeServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IList<CidadeDto>> GetCidades(EstadoEnum estado)
        {
            return await _restClient.GetJsonAsync<CidadeDto[]>($"cidades/{estado}");
        }

        public IList<EstadoValueObject> GetEstados()
        {
            var lista = new List<EstadoValueObject>();
            foreach (EstadoEnum item in Enum.GetValues(typeof(EstadoEnum)))
            {
                lista.Add(new EstadoValueObject { Codigo = item });
            }
            return lista;
        }
    }
}
