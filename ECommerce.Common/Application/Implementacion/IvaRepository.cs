using AutoMapper;
using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.DataBase;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Application.Implementacion
{
    public class IvaRepository : GenericRepository<Iva>, IIvaRepository
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public IvaRepository(ECommerceDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenericResponse<IvaDto>> DeactivateIvaAsync(IvaDto avatar)
        {
            try
            {
                var OnlyIva = await _dbContext
                    .Ivas.FirstOrDefaultAsync(c => c.Ivaid == avatar.IvaId);
                OnlyIva.IsActive = 0;
                _dbContext.Ivas.Update(OnlyIva);
                await SaveAllAsync();
                return new GenericResponse<IvaDto> { IsSuccess = true, Result = avatar };

            }
            catch (Exception ex)
            {
                return new GenericResponse<IvaDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Iva>> DeleteIvaAsync(int id)
        {
            try
            {
                var iva = await _dbContext.Ivas.FirstOrDefaultAsync(c => c.Ivaid == id);
                if (iva == null)
                {
                    return new GenericResponse<Iva> { IsSuccess = false, Message = "No hay Datos!" };
                }

                iva.IsActive = 0;

                _dbContext.Ivas.Update(iva);
                if (!await SaveAllAsync())
                {
                    return new GenericResponse<Iva> { IsSuccess = false, Message = "La operacion no realizada!" };
                }

                return new GenericResponse<Iva> { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Iva> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<List<IvaDto>> GetAllIvaAsync()
        {
            var listAll = await _dbContext.Ivas.Where(c => c.IsActive == 1).OrderBy(c => c.Ivaid).ToListAsync();
            var ListDto = new List<IvaDto>();

            foreach (var list in listAll)
            {
                ListDto.Add(_mapper.Map<IvaDto>(list));
            }
            return ListDto;
        }

        public async Task<GenericResponse<IvaDto>> GetOnlyIvaAsync(int id)
        {
            try
            {
                var Only = await _dbContext.Ivas.FirstOrDefaultAsync(c => c.Ivaid.Equals(id));
                if (Only == null)
                {
                    return new GenericResponse<IvaDto> { IsSuccess = false, Message = "No hay Datos!" };
                }
                var OnlyConcepto = _mapper.Map<IvaDto>(Only);
                return new GenericResponse<IvaDto> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<IvaDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Iva>> OnlyIvaGetAsync(int id)
        {
            try
            {
                var OnlyConcepto = await _dbContext.Ivas.FirstOrDefaultAsync(c => c.Ivaid.Equals(id));
                if (OnlyConcepto == null)
                {
                    return new GenericResponse<Iva> { IsSuccess = false, Message = "No hay Datos!" };
                }

                return new GenericResponse<Iva> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<Iva> { IsSuccess = false, Message = ex.Message };
            }
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
