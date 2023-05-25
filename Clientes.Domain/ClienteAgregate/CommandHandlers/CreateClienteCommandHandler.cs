using AutoMapper;
using Clientes.Domain.ClienteAgregate.Commands;
using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Domain.Contracts;
using Clientes.Shared;
using Clientes.Shared.FiltersModel;
using MediatR;

namespace Clientes.Domain.ClienteAgregate.CommandHandlers
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<Cliente>>
    {
        protected IRepository<Cliente, ClienteFilters> _repository;
        protected IMapper _mapper;
        protected IMediator _mediator;

        public CreateClienteCommandHandler(IRepository<Cliente, ClienteFilters> repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Response<Cliente>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var discipulo = _mapper.Map<Cliente>(request);
            if (discipulo.Invalid)
                return Response.Build(discipulo, discipulo.Validate());

            await _repository.Add(discipulo);

            return Response.Build(discipulo);
        }
    }
}
