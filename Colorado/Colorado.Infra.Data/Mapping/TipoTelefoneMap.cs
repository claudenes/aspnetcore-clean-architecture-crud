using Colorado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colorado.Infra.Data.Mapping
{
    public class TipoTelefoneMap : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.ToTable("TipoTelefone");
            builder.HasKey(x => x.CodigoTipoTelefone);
            builder.Property(x => x.CodigoTipoTelefone)
                .ValueGeneratedOnAdd()
                .HasColumnName("CodigoTipoTelefone")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.DescricaoTipoTelefone)
                .HasColumnName("DescricaoTipoTelefone")
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
