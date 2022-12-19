using ECommerce.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.DataBase
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext()
        {}
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        { }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Iva> Ivas { get; set; }
        public virtual DbSet<Medidum> Medida { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__AspNetRo__F92302F1E81A5D3A");

                entity.HasIndex(e => e.Rnombre, "UQ__AspNetRo__67C54CA911058A1B")
                    .IsUnique();

                entity.Property(e => e.RolId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Rnombre)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("RNombre");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AspNetUs__1788CC4C01DA5F28");

                entity.HasIndex(e => e.NickName, "UQ__AspNetUs__01E67C8B7B4D9906")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__AspNetUs__A9D10534E2536D8E")
                    .IsUnique();

                entity.HasIndex(e => e.Dni, "UQ__AspNetUs__C035B8DD6185110C")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__AspNetUs__C9F28456E018FC22")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Age)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(175)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastAccessedDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(175)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.PicturePath).IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.SecondSurName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.UserTimeZone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Genero");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRolId)
                    .HasName("PK__AspNetUs__80906A4CF4D80240");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AspNetRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AspNetUsers");
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.ToTable("Bodega");

                entity.HasIndex(e => e.Descripcion, "UQ__Bodega__92C53B6CF9327B14")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(175)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.ToTable("Concepto");

                entity.HasIndex(e => e.Descripcion, "UQ__Concepto__92C53B6C74973118")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamento");

                entity.HasIndex(e => e.Descripcion, "UQ__Departam__92C53B6C17FD0F3E")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .HasName("PK__Genero__4E24E9F77E46FC0A");

                entity.ToTable("Genero");

                entity.HasIndex(e => e.GeneroName, "UQ__Genero__8BC59BC02E215C1F")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.GeneroName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Iva>(entity =>
            {
                entity.ToTable("IVA");

                entity.HasIndex(e => e.Descripcion, "UQ__IVA__92C53B6CD47B7F2D")
                    .IsUnique();

                entity.Property(e => e.Ivaid).HasColumnName("IVAId");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(175)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tarifa).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Medidum>(entity =>
            {
                entity.HasKey(e => e.MedidaId)
                    .HasName("PK__Medida__5F7A0C02821E425C");

                entity.HasIndex(e => e.Descripcion, "UQ__Medida__92C53B6C91ACE236")
                    .IsUnique();

                entity.HasIndex(e => e.Escala, "UQ__Medida__9B63C44729ABBBAD")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(175)
                    .IsUnicode(false);

                entity.Property(e => e.Escala)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto);

                entity.ToTable("Producto");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Ivaid).HasColumnName("IVAId");

                entity.Property(e => e.Medida).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Notas).IsUnicode(false);

                entity.Property(e => e.PathImagen).IsUnicode(false);

                entity.Property(e => e.Pieza).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Departamento");

                entity.HasOne(d => d.Iva)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Ivaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_IVA");

                entity.HasOne(d => d.MedidaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.MedidaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Medida");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("TipoDocumento");

                entity.HasIndex(e => e.Descripcion, "UQ__TipoDocu__92C53B6C650AC1CE")
                    .IsUnique();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });
        }
    }

}
