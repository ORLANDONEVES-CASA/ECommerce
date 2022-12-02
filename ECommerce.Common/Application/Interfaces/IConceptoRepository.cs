using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;

namespace ECommerce.Common.Application.Interfaces
{

    public interface IConceptoRepository : IGenericRepositoryFactory<Concepto>
    {
        Task<List<ConceptoDto>> GetAllConceptoAsync();
        Task<GenericResponse<ConceptoDto>> GetOnlyConceptoAsync(int id);
        Task<GenericResponse<Concepto>> DeleteConceptoAsync(int id);
    }
}
