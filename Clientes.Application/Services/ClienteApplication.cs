using AutoMapper;
using Clientes.Application.Contracts;
using Clientes.Domain.ClienteAgregate.Commands;
using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Domain.Contracts;
using Clientes.Shared;
using Clientes.Shared.Dtos;
using Clientes.Shared.FiltersModel;
using Clientes.Shared.InputModels;
using MediatR;

namespace Clientes.Application.Services
{
    public class ClienteApplication : IApplicationServices<Cliente, ClienteDto, CreateClienteInput, UpdateClienteInput, ListClienteDto, ClienteFilters>
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        protected readonly IRepository<Cliente, ClienteFilters> _repository;

        public ClienteApplication(IMediator mediator, IMapper mapper, IRepository<Cliente, ClienteFilters> repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<ClienteDto>> Add(CreateClienteInput input)
        {
            var command = _mapper.Map<CreateClienteCommand>(input);
            var response = await _mediator.Send(command);
            return response.Map<ClienteDto>(_mapper);
        }

        public async Task<Response<bool>> Delete(int id)
        {
            var command = new RemoveClienteCommand(id);
            return await _mediator.Send(command);
        }

        public async Task<ClienteDto> Get(int id)
        {
            return _mapper.Map<ClienteDto>(await _repository.Get(id));
        }

        public async Task<IList<ListClienteDto>> Get(ClienteFilters filters)
        {
            return _mapper.Map<IList<ListClienteDto>>(await _repository.Get(filters));
        }

        public async Task<Response<ClienteDto>> Update(UpdateClienteInput input)
        {
            var command = _mapper.Map<UpdateClienteCommand>(input);
            var response = await _mediator.Send(command);
            return response.Map<ClienteDto>(_mapper);
        }
    }
}
