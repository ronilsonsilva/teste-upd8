using Clientes.Shared.ValueObject;

namespace Clientes.Shared.Dtos
{
    public class CidadeDto
    {
        public int CodigoIBGE { get; set; }
        public EstadoEnum Estado { get; set; }
        public string Nome { get; set; }
    }
}
