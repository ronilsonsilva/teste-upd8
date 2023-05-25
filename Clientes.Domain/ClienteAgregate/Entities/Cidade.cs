using Clientes.Shared.ValueObject;

namespace Clientes.Domain.ClienteAgregate.Entities
{
    public class Cidade
    {
        public int CodigoIBGE { get; set; }
        public EstadoEnum Estado { get; set; }
        public string Nome { get; set; }
    }
}
