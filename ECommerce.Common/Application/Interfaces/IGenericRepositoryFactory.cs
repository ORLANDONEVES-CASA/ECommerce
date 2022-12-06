using ECommerce.Common.Responses;

namespace ECommerce.Common.Application.Interfaces
{
    public interface IGenericRepositoryFactory<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllDataAsync();
        Task<GenericResponse<TEntity>> AddDataAsync(TEntity entity);
        Task<GenericResponse<TEntity>> UpdateDataAsync(TEntity entity);
        Task<GenericResponse<TEntity>> DeleteDataAsync(TEntity entity);
    }
}
