using AutoMapper;
using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.DataBase;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Application.Implementacion
{
    public class MedidumRepository : GenericRepository<Medidum>, IMedidumRepository
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public MedidumRepository(ECommerceDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenericResponse<MedidumDto>> DeactivateMedidumAsync(MedidumDto avatar)
        {
            try
            {
                var OnlyMedid = await _dbContext
                    .Medida.FirstOrDefaultAsync(c => c.MedidaId == avatar.MedidaId);
                OnlyMedid.IsActive = 0;
                _dbContext.Medida.Update(OnlyMedid);
                await SaveAllAsync();
                return new GenericResponse<MedidumDto> { IsSuccess = true, Result = avatar };

            }
            catch (Exception ex)
            {
                return new GenericResponse<MedidumDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Medidum>> DeleteMedidumAsync(int id)
        {
            try
            {
                var Medid = await _dbContext.Medida.FirstOrDefaultAsync(c => c.MedidaId == id);
                if (Medid == null)
                {
                    return new GenericResponse<Medidum> { IsSuccess = false, Message = "No hay Datos!" };
                }

                Medid.IsActive = 0;

                _dbContext.Medida.Update(Medid);
                if (!await SaveAllAsync())
                {
                    return new GenericResponse<Medidum> { IsSuccess = false, Message = "La operacion no realizada!" };
                }

                return new GenericResponse<Medidum> { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Medidum> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<List<MedidumDto>> GetAllMedidumAsync()
        {
            var listAll = await _dbContext.Medida.Where(c => c.IsActive == 1).OrderBy(c => c.MedidaId).ToListAsync();
            var ListDto = new List<MedidumDto>();

            foreach (var list in listAll)
            {
                ListDto.Add(_mapper.Map<MedidumDto>(list));
            }
            return ListDto;
        }

        public async Task<GenericResponse<MedidumDto>> GetOnlyMedidumAsync(int id)
        {
            try
            {
                var Only = await _dbContext.Medida.FirstOrDefaultAsync(c => c.MedidaId.Equals(id));
                if (Only == null)
                {
                    return new GenericResponse<MedidumDto> { IsSuccess = false, Message = "No hay Datos!" };
                }
                var OnlyConcepto = _mapper.Map<MedidumDto>(Only);
                return new GenericResponse<MedidumDto> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<MedidumDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Medidum>> OnlyMedidumGetAsync(int id)
        {
            try
            {
                var OnlyMedidum = await _dbContext.Medida.FirstOrDefaultAsync(c => c.MedidaId.Equals(id));
                if (OnlyMedidum == null)
                {
                    return new GenericResponse<Medidum> { IsSuccess = false, Message = "No hay Datos!" };
                }

                return new GenericResponse<Medidum> { IsSuccess = true, Result = OnlyMedidum };

            }
            catch (Exception ex)
            {
                return new GenericResponse<Medidum> { IsSuccess = false, Message = ex.Message };
            }
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
