using System.ComponentModel;

namespace Clientes.Shared.ValueObject
{
    public class EstadoValueObject
    {
        public EstadoValueObject()
        {
        }
        public EstadoValueObject(EstadoEnum codigo)
        {
            Codigo = codigo;
        }

        public EstadoEnum Codigo { get; set; }
        public string Nome
        {
            get { return GetDescription(Codigo); }
        }

        public string GetDescription(EstadoEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
