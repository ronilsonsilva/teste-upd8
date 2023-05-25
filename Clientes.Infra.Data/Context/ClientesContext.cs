using Clientes.Infra.Data.Context.Map;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infra.Data.Context
{
    public class ClientesContext : DbContext
    {
        public ClientesContext()
        {
        }

        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
