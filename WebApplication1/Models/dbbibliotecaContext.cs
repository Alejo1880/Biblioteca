using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class dbbibliotecaContext : DbContext
    {
        public dbbibliotecaContext()
        {
        }

        public dbbibliotecaContext(DbContextOptions<dbbibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Socio> Socio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ELPQJA51\\;Database=dbbiblioteca;User id=sa; Password=infoil");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.Idautor)
                    .HasName("PK__autor__6FC41E3C9CB49540");

                entity.ToTable("autor");

                entity.Property(e => e.Idautor).HasColumnName("idautor");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK__categori__140587C7286A314C");

                entity.ToTable("categoria");

                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__categori__72AFBCC6144E2B8E")
                    .IsUnique();

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__libro__5BC0F02658361C42");

                entity.ToTable("libro");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idautor).HasColumnName("idautor");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.Idautor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__libro__idautor__2E1BDC42");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__libro__idcategor__2F10007B");
            });

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.HasKey(e => e.Idsocio)
                    .HasName("PK__Socio__F70B2B55587E6B4E");

                entity.HasIndex(e => e.Dni)
                    .HasName("UQ__Socio__D87608A7ABCA2D15")
                    .IsUnique();

                entity.Property(e => e.Idsocio).HasColumnName("idsocio");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("fechanacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
