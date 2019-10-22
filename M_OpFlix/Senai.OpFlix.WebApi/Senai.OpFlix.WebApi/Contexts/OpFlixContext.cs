using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Formatos> Formatos { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Veiculos> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=M_OpFlix;User Id=sa;Pwd=132 ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Categoria)
                    .HasName("UQ__Categori__08015F8B6E91BB0B")
                    .IsUnique();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Formatos>(entity =>
            {
                entity.HasKey(e => e.IdFormato);

                entity.HasIndex(e => e.Formato)
                    .HasName("UQ__Formatos__32C163D470E905D3")
                    .IsUnique();

                entity.Property(e => e.IdFormato).ValueGeneratedOnAdd();

                entity.Property(e => e.Formato)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__Lancamen__7B406B56475B88CF")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__619B8048");

                entity.HasOne(d => d.IdFormatoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdFormato)
                    .HasConstraintName("FK__Lancament__IdFor__628FA481");

                entity.HasOne(d => d.IdVeiculosNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdVeiculos)
                    .HasConstraintName("FK__Lancament__IdVei__6383C8BA");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Usuarios__C1F8973137199597")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105340DD1C2D5")
                    .IsUnique();

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataEntrada)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veiculos>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo);

                entity.HasIndex(e => e.Veiculo)
                    .HasName("UQ__Veiculos__D44BF85B33A85251")
                    .IsUnique();

                entity.Property(e => e.Veiculo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
