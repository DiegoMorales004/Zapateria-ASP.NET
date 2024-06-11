using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zapateria.Models
{
    public partial class PruebaAPIPrendasContext : DbContext
    {
        public PruebaAPIPrendasContext()
        {
        }

        public PruebaAPIPrendasContext(DbContextOptions<PruebaAPIPrendasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Sucursale> Sucursales { get; set; } = null!;
        public virtual DbSet<Talla> Tallas { get; set; } = null!;
        public virtual DbSet<Zapato> Zapatos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdStock)
                    .HasName("PK__stock__A4B76DE5B9991915");

                entity.ToTable("stock");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.IdZapatos).HasColumnName("idZapatos");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sucursales_stock");

                entity.HasOne(d => d.IdZapatosNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdZapatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_zapatos_stock");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__sucursal__F707694C593BC277");

                entity.ToTable("sucursales");

                entity.HasIndex(e => e.Nombre, "UQ__sucursal__72AFBCC63FF0FE30")
                    .IsUnique();

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");
            });

            modelBuilder.Entity<Talla>(entity =>
            {
                entity.HasKey(e => e.IdTalla)
                    .HasName("PK__tallas__74EEA80D690FB17F");

                entity.ToTable("tallas");

                entity.Property(e => e.IdTalla).HasColumnName("idTalla");

                entity.Property(e => e.TallaAmerica)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("tallaAmerica");

                entity.Property(e => e.TallaCentimetros)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("tallaCentimetros");

                entity.Property(e => e.TallaEuropea)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("tallaEuropea");
            });

            modelBuilder.Entity<Zapato>(entity =>
            {
                entity.HasKey(e => e.IdZapato)
                    .HasName("PK__zapatos__CE3CAAB657611ED0");

                entity.ToTable("zapatos");

                entity.Property(e => e.IdZapato).HasColumnName("idZapato");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("date")
                    .HasColumnName("fechaSalida");

                entity.Property(e => e.NombreZapato)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("nombreZapato");

                entity.Property(e => e.Talla).HasColumnName("talla");

                entity.Property(e => e.UrlImagen)
                    .IsUnicode(false)
                    .HasColumnName("urlImagen");

                entity.HasOne(d => d.TallaNavigation)
                    .WithMany(p => p.Zapatos)
                    .HasForeignKey(d => d.Talla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_talla_zapatos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
