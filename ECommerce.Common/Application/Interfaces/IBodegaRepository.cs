using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;

namespace ECommerce.Common.Application.Interfaces
{
    public interface IBodegaRepository : IGenericRepositoryFactory<Bodega>
    {
        Task<List<BodegaDto>> GetAllBodegaAsync();
        Task<GenericResponse<BodegaDto>> GetOnlyBodegaAsync(int id);
        Task<GenericResponse<Bodega>> OnlyBodegaGetAsync(int id);
        Task<GenericResponse<Bodega>> DeleteBodegaAsync(int id);
        Task<GenericResponse<BodegaDto>> DeactivateBodegaAsync(BodegaDto avatar);
    }
}
