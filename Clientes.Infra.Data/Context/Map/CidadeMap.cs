using Clientes.Domain.ClienteAgregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infra.Data.Context.Map
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");
            builder.HasKey(x => x.CodigoIBGE);


            builder.Property(x => x.Nome)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(x => x.Estado)
                .IsRequired();
        }
    }
}
