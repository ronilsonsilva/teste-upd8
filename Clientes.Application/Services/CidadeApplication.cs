using AutoMapper;
using Clientes.Application.Contracts;
using Clientes.Domain.Contracts;
using Clientes.Shared.Dtos;
using Clientes.Shared.ValueObject;

namespace Clientes.Application.Services
{
    public class CidadeApplication : ICidadeApplication
    {
        protected readonly ICidadeRepository _repository;
        protected readonly IMapper _mapper;

        public CidadeApplication(ICidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CidadeDto>> GetCidades(EstadoEnum estado)
        {
            return _mapper.Map<IList<CidadeDto>>(await _repository.Get(estado));
        }
    }
}
