using Clientes.Application.Contracts;
using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Shared;
using Clientes.Shared.Dtos;
using Clientes.Shared.FiltersModel;
using Clientes.Shared.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IApplicationServices<Cliente, ClienteDto, CreateClienteInput, UpdateClienteInput, ListClienteDto, ClienteFilters> _clienteServices;

        public ClienteController(IApplicationServices<Cliente, ClienteDto, CreateClienteInput, UpdateClienteInput, ListClienteDto, ClienteFilters> clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost("list")]
        [ProducesResponseType(typeof(IEnumerable<ListClienteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> List([FromBody] ClienteFilters filters)
        {
            var clientes = await _clienteServices.Get(filters);
            if(clientes == null) return NoContent();
            return Ok(clientes);
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _clienteServices.Get(id);
            if(cliente == null) return NotFound();
            return Ok(cliente);
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateClienteInput input)
        {
            var response = await _clienteServices.Add(input);
            if(!response.Ok) return BadRequest(response);

            return Created("", response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdateClienteInput input)
        {
            var response = await _clienteServices.Update(input);
            if(!response.Ok) return BadRequest(Response);
            return Ok(response);
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clienteServices.Delete(id);
            if (!response.Ok) return BadRequest(Response);
            return Ok(response);
        }
    }
}
