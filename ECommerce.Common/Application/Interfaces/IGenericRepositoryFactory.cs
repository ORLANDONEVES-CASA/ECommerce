using ECommerce.Common.Responses;

namespace ECommerce.Common.Application.Interfaces
{
    public interface IGenericRepositoryFactory<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<GenericResponse<TEntity>> AddAsync(TEntity entity);
        Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<GenericResponse<TEntity>> DeleteAsync(TEntity entity);
    }
}
