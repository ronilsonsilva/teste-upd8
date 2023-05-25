using Clientes.Shared;
using MediatR;

namespace Clientes.Domain.ClienteAgregate.Commands
{
    public class RemoveClienteCommand : IRequest<Response<bool>>
    {
        public RemoveClienteCommand()
        {
        }
        public RemoveClienteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
