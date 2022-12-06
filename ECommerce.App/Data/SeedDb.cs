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
            await CheckBodegasAsync();
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
        private async Task CheckBodegasAsync()
        {
            if (!_dataContext.Bodegas.Any())
            {
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Principal", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Envigado", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Itagüí", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Sabaneta", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Medellín", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Bello", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Cocorna", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "Puerto Berrio de los Dolores", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Bodegas.Add(new Bodega { Descripcion = "La Estrella", IsActive = 1, RegistrationDate = DateTime.UtcNow });



                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
