using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(k => k.Telefone).HasColumnType("CHAR(11)");
            builder.Property(k => k.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(k => k.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(k => k.Estado).HasMaxLength(60).IsRequired();
        }
    }
}
