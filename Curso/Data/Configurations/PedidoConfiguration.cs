using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoEFCore.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(k => k.Id);
            builder.Property(k => k.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(k => k.Status).HasConversion<string>();
            builder.Property(k => k.TipoFrete).HasConversion<int>();
            builder.Property(k => k.Observacao).HasColumnType("VARCHAR(512)");

            builder.HasMany(k => k.Itens)
            .WithOne(k => k.Pedido)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
