using Clientes.Shared;

namespace Clientes.Application.Contracts
{
    public interface IApplicationServices<TEntity, TEntityDto, CreateInput, UpdateInput, ListDto, FilterModel>
    {
        Task<Response<TEntityDto>> Add(CreateInput dto);
        Task<Response<TEntityDto>> Update(UpdateInput dto);
        Task<Response<bool>> Delete(int id);
        Task<TEntityDto> Get(int id);
        Task<IList<ListDto>> Get(FilterModel filters);
    }
}
