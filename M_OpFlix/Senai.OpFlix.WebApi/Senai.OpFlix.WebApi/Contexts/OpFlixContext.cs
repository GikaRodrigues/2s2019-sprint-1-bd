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
        public virtual DbSet<Favoritos> Favoritos { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<PlataformaLancamentos> PlataformaLancamentos { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=M_OpFlix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Categoria)
                    .HasName("UQ__Categori__08015F8BDD2965F4")
                    .IsUnique();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Favoritos>(entity =>
            {
                entity.HasKey(e => e.IdFavorito);

                entity.HasOne(d => d.IdLacamentosNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdLacamentos)
                    .HasConstraintName("FK__Favoritos__IdLac__797309D9");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Favoritos__IdUsu__787EE5A0");
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.TempoDeDuracao)
                    .HasName("UQ__Lancamen__0FCC471EEC473356")
                    .IsUnique();

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__Lancamen__7B406B560C2B107D")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__71D1E811");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Lancament__IdTip__72C60C4A");
            });

            modelBuilder.Entity<PlataformaLancamentos>(entity =>
            {
                entity.HasKey(e => e.IdPlataformaLancamentos);

                entity.HasOne(d => d.IdLancamentoNavigation)
                    .WithMany(p => p.PlataformaLancamentos)
                    .HasForeignKey(d => d.IdLancamento)
                    .HasConstraintName("FK__Plataform__IdLan__7D439ABD");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.PlataformaLancamentos)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__Plataform__IdPla__7C4F7684");
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Plataforma)
                    .HasName("UQ__Platafor__3FCED092B10177B1")
                    .IsUnique();

                entity.Property(e => e.Plataforma)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipos>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__Tipos__8E762CB4042CF7BA")
                    .IsUnique();

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Usuarios__C1F89731EF245393")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105345907E21D")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuarios__7D8FE3B2C2D1BF1B")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuarios__7ABB9731314E52AE")
                    .IsUnique();

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
