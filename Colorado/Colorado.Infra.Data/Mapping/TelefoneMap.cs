using Colorado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colorado.Infra.Data.Mapping
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");
            builder.HasKey(t => new { t.CodigoCliente, t.NumeroTelefone });
            builder.HasOne(t => t.TipoTelefone)
        .WithMany()                          // ou .WithMany(tt => tt.Telefones)
        .HasForeignKey(t => t.CodigoTipoTelefone);
            builder.Property(x => x.CodigoCliente)
                .ValueGeneratedOnAdd()
                .HasColumnName("CodigoCliente")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.NumeroTelefone)
                .HasColumnName("NumeroTelefone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.CodigoTipoTelefone)
                .HasColumnName("CodigoTipoTelefone")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.Operadora)
                .HasColumnName("Operadora")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("Bit")
                .IsRequired();
            builder.Property(x => x.DataInsercao)
                .HasColumnName("DataInsercao")
                .HasColumnType("DATETIME")
                .IsRequired();
            builder.Property(x => x.UsuarioInsercao)
                .HasColumnName("UsuarioInsercao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();

        }
    }
}
