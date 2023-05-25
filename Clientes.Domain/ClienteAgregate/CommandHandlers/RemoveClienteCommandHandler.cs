using AutoMapper;
using Clientes.Domain.ClienteAgregate.Commands;
using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Domain.Contracts;
using Clientes.Shared;
using Clientes.Shared.FiltersModel;
using MediatR;

namespace Clientes.Domain.ClienteAgregate.CommandHandlers
{
    public class RemoveClienteCommandHandler : IRequestHandler<RemoveClienteCommand, Response<bool>>
    {
        protected IRepository<Cliente, ClienteFilters> _repository;
        protected IMapper _mapper;
        protected IMediator _mediator;

        public RemoveClienteCommandHandler(IRepository<Cliente, ClienteFilters> repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Response<bool>> Handle(RemoveClienteCommand request, CancellationToken cancellationToken)
        {
            var discipulo = await _repository.Get(request.Id);
            if (discipulo == null)
                return Response.Build(false).AddError("Cliente não encontrado");

            await _repository.Delete(request.Id);

            return Response.Build(true);
        }
    }
}
