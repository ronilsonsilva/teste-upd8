using Clientes.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infra.Data.Context.Map
{
    public class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        protected readonly string _nomeTabela;
        public BaseMap(string nomeTabela)
        {
            this._nomeTabela = nomeTabela;
        }
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(this._nomeTabela);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Ignore(x => x.Invalid);
            builder.Ignore(x => x.Valid);
        }
    }
}
