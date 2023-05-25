using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Domain.Contracts;
using Clientes.Shared.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infra.Data.Context.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        protected readonly ClientesContext _context;

        public CidadeRepository(ClientesContext context)
        {
            _context = context;
        }

        public async Task<IList<Cidade>> Get()
        {
            return await _context.Set<Cidade>().ToListAsync();
        }

        public async Task<IList<Cidade>> Get(EstadoEnum estado)
        {
            return await _context.Set<Cidade>().Where(x => x.Estado == estado).ToListAsync();
        }

        public async Task<Cidade> Get(int codigoIbge)
        {
            return await _context.Set<Cidade>().FindAsync(codigoIbge);
        }
    }
}
