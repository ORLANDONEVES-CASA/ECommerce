using Microsoft.EntityFrameworkCore;
using ECommerce.Common.DataBase;
using ECommerce.Common.Entities;

namespace ECommerce.App.Data
{
    public class SeedDb
    {
        private readonly ECommerceDbContext _dataContext;

        public SeedDb(ECommerceDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task SeedAsync() {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckConceptoAsync();
        }
        private async Task CheckConceptoAsync()
        {
            if (!_dataContext.Conceptos.Any())
            {
                _dataContext.Conceptos.Add(new Concepto { Descripcion = "Averia", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Conceptos.Add(new Concepto { Descripcion = "Autoconsumo", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Conceptos.Add(new Concepto { Descripcion = "Hurto", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Conceptos.Add(new Concepto { Descripcion = "Donación", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
