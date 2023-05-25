using Clientes.Shared.Dtos;
using Clientes.Shared.FiltersModel;
using Clientes.Shared.ValueObject;

namespace Clientes.WebApp.Models
{
    public class IndexViewModel
    {
        public IList<ListClienteDto> Clientes { get; set; } = new List<ListClienteDto>();
        public ClienteFilters Filtro { get; set; } = new(null, null, null, null, null, null);
        public IList<EstadoValueObject> Estados { get; set; } = new List<EstadoValueObject>();
        public IList<CidadeDto> Cidades { get; set; } = new List<CidadeDto>();
    }
}
