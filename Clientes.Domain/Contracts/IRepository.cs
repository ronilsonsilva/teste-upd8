using Clientes.Shared;

namespace Clientes.Domain.Contracts
{
    public interface IRepository<TEntity, FilterModel> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> Get(int id);
        Task<IList<TEntity>> Get();
        Task<IList<TEntity>> Get(FilterModel filters);
    }
}
