using MediatR;

namespace Clientes.Shared
{
    public abstract class DomainEventBase<T> : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
        public T Entity { get; set; }
    }
}
