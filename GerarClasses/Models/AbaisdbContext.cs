using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAbais.DOMAIN.Models;

public partial class AbaisdbContext : DbContext
{
    public AbaisdbContext()
    {
    }

    public AbaisdbContext(DbContextOptions<AbaisdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Aluguel> Aluguels { get; set; }

    public virtual DbSet<Imovel> Imovels { get; set; }

    public virtual DbSet<Inquilino> Inquilinos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DERSO\\SQLEXPRESS;Database=abaisdb;User Id=sa;Password=sa;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__administ__3213E83FCA893D9D");

            entity.ToTable("administrador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Aluguel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__aluguel__3213E83F375D4E7F");

            entity.ToTable("aluguel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.DataFim).HasColumnName("dataFim");
            entity.Property(e => e.DataInicio).HasColumnName("dataInicio");
            entity.Property(e => e.ImovelId).HasColumnName("imovel_id");
            entity.Property(e => e.InquilinoId).HasColumnName("inquilino_id");
            entity.Property(e => e.Pagamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pagamento");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.Administrador).WithMany(p => p.Aluguels)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aluguel__adminis__45F365D3");

            entity.HasOne(d => d.Imovel).WithMany(p => p.Aluguels)
                .HasForeignKey(d => d.ImovelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aluguel__imovel___46E78A0C");

            entity.HasOne(d => d.Inquilino).WithMany(p => p.Aluguels)
                .HasForeignKey(d => d.InquilinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aluguel__inquili__44FF419A");
        });

        modelBuilder.Entity<Imovel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__imovel__3213E83FCDE51795");

            entity.ToTable("imovel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Inquilino>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__inquilin__3213E83F88FA696C");

            entity.ToTable("inquilino");

            entity.HasIndex(e => e.Email, "UQ__inquilin__AB6E616441B0D2D5").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__inquilin__D836E71FE6DCA551").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
