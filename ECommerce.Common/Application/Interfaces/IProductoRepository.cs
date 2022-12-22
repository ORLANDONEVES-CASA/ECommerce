using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;


namespace ECommerce.Common.Application.Interfaces
{
    public interface IProductoRepository : IGenericRepositoryFactory<Producto>
    {
        Task<List<ProductoDto>> GetAllProductoAsync();
        Task<GenericResponse<ProductoDto>> GetOnlyProducoAsync(int id);
        Task<GenericResponse<Producto>> OnlyProducoGetAsync(int id);
        Task<GenericResponse<Producto>> DeleteProducoAsync(int id);
        Task<GenericResponse<ProductoDto>> DeactivateProducoAsync(ProductoDto avatar);
    }
}
