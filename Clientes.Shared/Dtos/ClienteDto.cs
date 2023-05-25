using Clientes.Shared.ValueObject;

namespace Clientes.Shared.Dtos
{
    public class ClienteDto : BaseDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public string Endereco { get; set; }
        public int CodigoCidade { get; set; }
        public EstadoEnum Estado { get; set; }
        public CidadeDto Cidade { get; set; }
    }
}
