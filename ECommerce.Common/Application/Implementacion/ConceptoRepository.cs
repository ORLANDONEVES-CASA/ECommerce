using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.DataBase;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Application.Implementacion
{
    public class ConceptoRepository : GenericRepository<Concepto>, IConceptoRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public ConceptoRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<GenericResponse<Concepto>> DeleteConceptoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ConceptoDto>> GetAllConceptoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<ConceptoDto>> GetOnlyConceptoAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
