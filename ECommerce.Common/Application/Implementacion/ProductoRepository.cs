using AutoMapper;
using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.DataBase;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using ECommerce.Common.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Application.Implementacion
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {

       private readonly ECommerceDbContext _dbContext;
       private readonly IMapper _mapper;

       public ProductoRepository(ECommerceDbContext dbContext, IMapper mapper) : base(dbContext)
       {
           _dbContext = dbContext;
           _mapper = mapper;
       }

       public async Task<GenericResponse<ProductoDto>> DeactivateProducoAsync(ProductoDto avatar)
       {
           try
           {
               var OnlyDepart = await _dbContext
                   .Productos.FirstOrDefaultAsync(c => c.Idproducto == avatar.IdProducto);
              OnlyDepart.IsActive = 0;
               _dbContext.Productos.Update(OnlyDepart);
               await SaveAllAsync();
               return new GenericResponse<ProductoDto> { IsSuccess = true, Result = avatar };
           }
           catch (Exception ex)
           {
               return new GenericResponse<ProductoDto> { IsSuccess = false, Message = ex.Message };
           }
       }

       public async Task<GenericResponse<Producto>> DeleteProducoAsync(int id)
       {
           try
           {
              var Depto = await _dbContext.Departamentos.FirstOrDefaultAsync(c => c.DepartamentoId == id);
               if (Depto == null)
               {
                   return new GenericResponse<Producto> { IsSuccess = false, Message = "No hay Datos!" };
               }
               Depto.IsActive = 0;
               _dbContext.Departamentos.Update(Depto);
               if (!await SaveAllAsync())
               {
                   return new GenericResponse<Producto> { IsSuccess = false, Message = "La operacion no realizada!" };
               }
               return new GenericResponse<Producto> { IsSuccess = true };
            }
            catch (Exception ex)
            {
               return new GenericResponse<Producto> { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<List<ProductoDto>> GetAllProductoAsync()
        {
           var listAll = await _dbContext.Productos.Where(c => c.IsActive == 1).OrderBy(c => c.Idproducto).ToListAsync();
           var ListDto = new List<ProductoDto>();
           foreach (var list in listAll)
           {
               ListDto.Add(_mapper.Map<ProductoDto>(list));
           }
           return ListDto;
        }

        public async Task<GenericResponse<ProductoDto>> GetOnlyProducoAsync(int id)
        {
           try
           {
               var Only = await _dbContext.Productos.FirstOrDefaultAsync(c => c.Idproducto.Equals(id));
               if (Only == null)
               {
                  return new GenericResponse<ProductoDto> { IsSuccess = false, Message = "No hay Datos!" };
               }
               var OnlyConcepto = _mapper.Map<ProductoDto>(Only);
               return new GenericResponse<ProductoDto> { IsSuccess = true, Result = OnlyConcepto };

           }
           catch (Exception ex)
           {
               return new GenericResponse<ProductoDto> { IsSuccess = false, Message = ex.Message };
           }
        }

        public async Task<GenericResponse<Producto>> OnlyProducoGetAsync(int id)
        {
           try
           {
               var OnlyConcepto = await _dbContext.Productos.FirstOrDefaultAsync(c => c.Idproducto.Equals(id));
               if (OnlyConcepto == null)
               {
                   return new GenericResponse<Producto> { IsSuccess = false, Message = "No hay Datos!" };
               }
               return new GenericResponse<Producto> { IsSuccess = true, Result = OnlyConcepto };
           }
           catch (Exception ex)
           {
              return new GenericResponse<Producto> { IsSuccess = false, Message = ex.Message };
           }
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}