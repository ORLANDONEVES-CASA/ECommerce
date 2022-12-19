using AutoMapper;
using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.DataBase;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Application.Implementacion
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartamentoRepository(ECommerceDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenericResponse<DepartamentoDto>> DeactivateDepartamentoAsync(DepartamentoDto avatar)
        {
            try
            {
                var OnlyDepart = await _dbContext
                    .Departamentos.FirstOrDefaultAsync(c => c.DepartamentoId == avatar.DepartamentoId);
                OnlyDepart.IsActive = 0;
                _dbContext.Departamentos.Update(OnlyDepart);
                await SaveAllAsync();
                return new GenericResponse<DepartamentoDto> { IsSuccess = true, Result = avatar };

            }
            catch (Exception ex)
            {
                return new GenericResponse<DepartamentoDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Departamento>> DeleteDepartamentoAsync(int id)
        {
            try
            {
                var Depto = await _dbContext.Departamentos.FirstOrDefaultAsync(c => c.DepartamentoId == id);
                if (Depto == null)
                {
                    return new GenericResponse<Departamento> { IsSuccess = false, Message = "No hay Datos!" };
                }

                Depto.IsActive = 0;

                _dbContext.Departamentos.Update(Depto);
                if (!await SaveAllAsync())
                {
                    return new GenericResponse<Departamento> { IsSuccess = false, Message = "La operacion no realizada!" };
                }

                return new GenericResponse<Departamento> { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new GenericResponse<Departamento> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<List<DepartamentoDto>> GetAllDepartamentoAsync()
        {
            var listAll = await _dbContext.Departamentos.Where(c => c.IsActive == 1).OrderBy(c => c.DepartamentoId).ToListAsync();
            var ListDto = new List<DepartamentoDto>();

            foreach (var list in listAll)
            {
                ListDto.Add(_mapper.Map<DepartamentoDto>(list));
            }
            return ListDto;
        }

        public async Task<GenericResponse<DepartamentoDto>> GetOnlyDepartamentoAsync(int id)
        {
            try
            {
                var Only = await _dbContext.Departamentos.FirstOrDefaultAsync(c => c.DepartamentoId.Equals(id));
                if (Only == null)
                {
                    return new GenericResponse<DepartamentoDto> { IsSuccess = false, Message = "No hay Datos!" };
                }
                var OnlyConcepto = _mapper.Map<DepartamentoDto>(Only);
                return new GenericResponse<DepartamentoDto> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<DepartamentoDto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<GenericResponse<Departamento>> OnlyDepartamentoGetAsync(int id)
        {
            try
            {
                var OnlyConcepto = await _dbContext.Departamentos.FirstOrDefaultAsync(c => c.DepartamentoId.Equals(id));
                if (OnlyConcepto == null)
                {
                    return new GenericResponse<Departamento> { IsSuccess = false, Message = "No hay Datos!" };
                }

                return new GenericResponse<Departamento> { IsSuccess = true, Result = OnlyConcepto };

            }
            catch (Exception ex)
            {
                return new GenericResponse<Departamento> { IsSuccess = false, Message = ex.Message };
            }
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
