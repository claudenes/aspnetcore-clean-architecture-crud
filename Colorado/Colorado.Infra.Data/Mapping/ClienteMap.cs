using Colorado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colorado.Infra.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.CodigoCliente);
            builder.HasMany(x => x.Telefones);
            builder.Property(x => x.CodigoCliente)
                .ValueGeneratedOnAdd()
                .HasColumnName("CodigoCliente")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.NomeFantasia)
                .HasColumnName("NomeFantasia")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.TipoPessoa)
                .HasColumnName("TipoPessoa")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Documento)
                .HasColumnName("Documento")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Endereco)
                .HasColumnName("Endereco")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Complemento)
                .HasColumnName("Complemento")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.CEP)
                .HasColumnName("CEP")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.UF)
                .HasColumnName("UF")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
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
