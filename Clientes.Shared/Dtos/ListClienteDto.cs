using Clientes.Shared.ValueObject;

namespace Clientes.Shared.Dtos
{
    public class ListClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public EstadoValueObject Estado { get; set; }
        public string Cidade { get; set; }
    }
}
