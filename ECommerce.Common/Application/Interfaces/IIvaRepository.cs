using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;

namespace ECommerce.Common.Application.Interfaces
{
    public interface IIvaRepository : IGenericRepositoryFactory<Iva>
    {
        Task<List<IvaDto>> GetAllIvaAsync();
        Task<GenericResponse<IvaDto>> GetOnlyIvaAsync(int id);
        Task<GenericResponse<Iva>> OnlyIvaGetAsync(int id);
        Task<GenericResponse<Iva>> DeleteIvaAsync(int id);
        Task<GenericResponse<IvaDto>> DeactivateIvaAsync(IvaDto avatar);
    }
}
