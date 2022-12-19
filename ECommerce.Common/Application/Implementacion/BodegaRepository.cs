using AutoMapper;
using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.DataBase;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Application.Implementacion
{
    public class BodegaRepository : GenericRepository<Bodega>, IBodegaRepository
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public BodegaRepository(ECommerceDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenericResponse<BodegaDto>> DeactivateBodegaAsync(BodegaDto avatar)
        {
            try
            {
                var OnlyBodega = await _dbContext
                    .Bodegas.FirstOrDefaultAsync(c => c.BodegaId == avatar.BodegaId);
                OnlyBodega.IsActive = 0;
                _dbContext.Bodegas.Update(OnlyBodega);
                await SaveAllAsync();
                return new GenericResponse<BodegaDto> { IsSuccess = true, Result = avatar };

            }
            catch (Exception ex)
            {
                return new GenericResponse<BodegaDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Bodega>> DeleteBodegaAsync(int id)
        {
            try
            {
                var bodega = await _dbContext.Bodegas.FirstOrDefaultAsync(c => c.BodegaId == id);
                if (bodega == null)
                {
                    return new GenericResponse<Bodega> { IsSuccess = false, Message = "No hay Datos!" };
                }

                bodega.IsActive = 0;

                _dbContext.Bodegas.Update(bodega);
                if (!await SaveAllAsync())
                {
                    return new GenericResponse<Bodega> { IsSuccess = false, Message = "La operacion no realizada!" };
                }

                return new GenericResponse<Bodega> { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Bodega> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<List<BodegaDto>> GetAllBodegaAsync()
        {
            var listAll = await _dbContext.Bodegas.Where(c => c.IsActive == 1).OrderBy(c => c.BodegaId).ToListAsync();
            var ListDto = new List<BodegaDto>();

            foreach (var list in listAll)
            {
                ListDto.Add(_mapper.Map<BodegaDto>(list));
            }
            return ListDto;
        }

        public async Task<GenericResponse<BodegaDto>> GetOnlyBodegaAsync(int id)
        {
            try
            {
                var Only = await _dbContext.Bodegas.FirstOrDefaultAsync(c => c.BodegaId.Equals(id));
                if (Only == null)
                {
                    return new GenericResponse<BodegaDto> { IsSuccess = false, Message = "No hay Datos!" };
                }
                var OnlyConcepto = _mapper.Map<BodegaDto>(Only);
                return new GenericResponse<BodegaDto> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<BodegaDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Bodega>> OnlyBodegaGetAsync(int id)
        {
            try
            {
                var OnlyConcepto = await _dbContext.Bodegas.FirstOrDefaultAsync(c => c.BodegaId.Equals(id));
                if (OnlyConcepto == null)
                {
                    return new GenericResponse<Bodega> { IsSuccess = false, Message = "No hay Datos!" };
                }

                return new GenericResponse<Bodega> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<Bodega> { IsSuccess = false, Message = ex.Message };
            }
        }
        private async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
