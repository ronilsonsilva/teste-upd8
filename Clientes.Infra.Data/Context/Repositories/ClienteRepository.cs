using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Shared.FiltersModel;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infra.Data.Context.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente, ClienteFilters>
    {
        public ClienteRepository(ClientesContext context) : base(context)
        {
        }

        public async override Task<Cliente> Get(int id)
        {
            return await _context.Set<Cliente>().Include(x => x.Cidade).FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IList<Cliente>> Get(ClienteFilters filters)
        {
            
            var clientes = _context.Set<Cliente>().AsQueryable();
            if (!string.IsNullOrEmpty(filters.Cpf))
                clientes = clientes.Where(x => x.Cpf == filters.Cpf);
            
            if (!string.IsNullOrEmpty(filters.Nome))
                clientes = clientes.Where(x => x.Nome == filters.Nome);

            if (filters.Estado.HasValue)
                clientes = clientes.Where(x => x.Estado.Equals(filters.Estado));

            if (filters.CodigoCidade.HasValue)
                clientes = clientes.Where(x => x.CodigoCidade == filters.CodigoCidade);

            if (filters.DataNascimento.HasValue)
                clientes = clientes.Where(x => x.DataNascimento == filters.DataNascimento);

            if (filters.Sexo.HasValue)
                clientes = clientes.Where(x => x.Sexo.Equals(filters.Sexo.Value));

            return await clientes.ToListAsync();
        }
    }
}
