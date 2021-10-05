using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoEFCore.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(k => k.Valor).IsRequired();
            builder.Property(k => k.Desconto).IsRequired();
        }
    }
}
