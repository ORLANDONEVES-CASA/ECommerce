using AutoMapper;
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
        private readonly IMapper _mapper;

        public ConceptoRepository(ECommerceDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

       
        public async Task<GenericResponse<Concepto>> DeleteConceptoAsync(int id)
        {
            try
            {
                var concepto = await _dbContext.Conceptos.FirstOrDefaultAsync(c => c.ConceptoId == id);
                if (concepto==null)
                {
                    return new GenericResponse<Concepto> { IsSuccess = false, Message = "No hay Datos!" };
                }

                concepto.IsActive = 0;

                _dbContext.Conceptos.Update(concepto);
                if (! await SaveAllAsync())
                {
                    return new GenericResponse<Concepto> { IsSuccess = false, Message = "La operacion no realizada!" };
                } 

                return new GenericResponse<Concepto> { IsSuccess=true };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Concepto> { IsSuccess=false, Message= ex.Message };
            }
        }

        public async Task<List<ConceptoDto>> GetAllConceptoAsync()
        {
            var listAll = await _dbContext.Conceptos.Where(c => c.IsActive == 1).OrderBy(c => c.ConceptoId).ToListAsync();
            var ListDto = new List<ConceptoDto>();

            foreach (var list in listAll)
            {
                ListDto.Add(_mapper.Map<ConceptoDto>(list));
            }
            return ListDto;
        }

        public async Task<GenericResponse<ConceptoDto>> GetOnlyConceptoAsync(int id)
        {
            
            try
            {
                var Only = await _dbContext.Conceptos.FirstOrDefaultAsync(c => c.ConceptoId.Equals(id));
                if (Only == null)
                {
                    return new GenericResponse<ConceptoDto> { IsSuccess = false, Message = "No hay Datos!" };
                }
                var OnlyConcepto = _mapper.Map<ConceptoDto>(Only);
                return new GenericResponse<ConceptoDto> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<ConceptoDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<ConceptoDto>> DeactivateConceptoAsync(ConceptoDto avatar)
        {
            try
            {
                var OnlyConcepto = await _dbContext.Conceptos.FirstOrDefaultAsync(c => c.ConceptoId == avatar.ConceptoId);
                OnlyConcepto.IsActive = 0;
                _dbContext.Conceptos.Update(OnlyConcepto);
               await SaveAllAsync();
                return new GenericResponse<ConceptoDto> { IsSuccess = true, Result = avatar };

            }
            catch (Exception ex)
            {
                return new GenericResponse<ConceptoDto> { IsSuccess = false, Message = ex.Message };
            }
        }



        private async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<GenericResponse<Concepto>> OnlyConceptoGetAsync(int id)
        {
            try
            {
                var OnlyConcepto = await _dbContext.Conceptos.FirstOrDefaultAsync(c => c.ConceptoId.Equals(id));
                if (OnlyConcepto == null)
                {
                    return new GenericResponse<Concepto> { IsSuccess = false, Message = "No hay Datos!" };
                }
                
                return new GenericResponse<Concepto> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<Concepto> { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
