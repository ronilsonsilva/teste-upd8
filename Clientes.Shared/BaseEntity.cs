using FluentValidation.Results;

namespace Clientes.Shared
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Invalid => !Valid;
        public bool Valid => this.Validate().IsValid;

        public abstract ValidationResult Validate();
    }
}
