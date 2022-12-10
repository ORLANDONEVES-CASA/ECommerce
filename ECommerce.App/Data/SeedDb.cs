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
            await CheckDepartamentosAsync();
            await CheckIvaAsync();
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

        private async Task CheckDepartamentosAsync()
        {
            if (!_dataContext.Departamentos.Any())
            {
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Licores", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Aseo Personal", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Aseo Hogar", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Ferretería", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Niños y Niñas", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Interior Masculino", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Interior Femenino", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Frutas y Verduras", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Granos", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Electrodomésticos", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Farmacia", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Panadería", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Belleza Mujer", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Jugos Naturales", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Deporte", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Literatura", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Arte", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Lacteos", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Seguridad Personal", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Charcutería", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Carnicería", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Departamentos.Add(new Departamento { Descripcion = "Salsas", IsActive = 1, RegistrationDate = DateTime.UtcNow });
                
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckIvaAsync()
        {
            if (!_dataContext.Ivas.Any())
            {
                _dataContext.Ivas.Add(new Iva { Descripcion = "Excluido", Tarifa = 0.0M, IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Ivas.Add(new Iva { Descripcion = "Exento", Tarifa = 0.0M, IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Ivas.Add(new Iva { Descripcion = "IVA 10%", Tarifa = 0.10M, IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Ivas.Add(new Iva { Descripcion = "IVA 16%", Tarifa = 0.16M, IsActive = 1, RegistrationDate = DateTime.UtcNow });
                _dataContext.Ivas.Add(new Iva { Descripcion = "IVA 20%", Tarifa = 0.20M, IsActive = 1, RegistrationDate = DateTime.UtcNow });

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
