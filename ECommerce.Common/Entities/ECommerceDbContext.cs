using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Entities
{
    public partial class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext()
        {
        }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }




    }
}
