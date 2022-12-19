using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;

namespace ECommerce.Common.Application.Interfaces
{
    public interface IMedidumRepository : IGenericRepositoryFactory<Medidum>
    {
        Task<List<MedidumDto>> GetAllMedidumAsync();
        Task<GenericResponse<MedidumDto>> GetOnlyMedidumAsync(int id);
        Task<GenericResponse<Medidum>> OnlyMedidumGetAsync(int id);
        Task<GenericResponse<Medidum>> DeleteMedidumAsync(int id);
        Task<GenericResponse<MedidumDto>> DeactivateMedidumAsync(MedidumDto avatar);
    }
}
