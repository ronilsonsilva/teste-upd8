using Clientes.Domain.ClienteAgregate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infra.Data.Context.Map
{
    public class ClienteMap : BaseMap<Cliente>
    {
        public ClienteMap(string nomeTabela = "Cliente") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Sexo).IsRequired();
            builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Endereco).HasMaxLength(512).IsRequired();
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.CodigoCidade).IsRequired();

            builder.HasOne(x => x.Cidade).WithMany().HasForeignKey(x => x.CodigoCidade);

            base.Configure(builder);
        }
    }
}
