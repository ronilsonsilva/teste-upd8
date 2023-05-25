using Clientes.Application.Contracts;
using Clientes.Shared.Dtos;
using Clientes.Shared.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        protected readonly ICidadeApplication _application;

        public CidadesController(ICidadeApplication application)
        {
            _application = application;
        }

        [HttpGet("{estado}")]
        [ProducesResponseType(typeof(IEnumerable<CidadeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(EstadoEnum estado)
        {
            var cidades = await _application.GetCidades(estado);
            if (cidades == null) return NoContent();
            return Ok(cidades);
        }
    }
}
