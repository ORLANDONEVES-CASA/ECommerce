using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;

namespace ECommerce.Common.Application.Interfaces
{
    public interface IDepartamentoRepository : IGenericRepositoryFactory<Departamento>
    {
        Task<List<DepartamentoDto>> GetAllDepartamentoAsync();
        Task<GenericResponse<DepartamentoDto>> GetOnlyDepartamentoAsync(int id);
        Task<GenericResponse<Departamento>> OnlyDepartamentoGetAsync(int id);
        Task<GenericResponse<Departamento>> DeleteDepartamentoAsync(int id);
        Task<GenericResponse<DepartamentoDto>> DeactivateDepartamentoAsync(DepartamentoDto avatar);
    }
}
