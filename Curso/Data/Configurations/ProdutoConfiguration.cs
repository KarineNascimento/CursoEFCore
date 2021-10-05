using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoEFCore.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(k => k.Id);
            builder.Property(k => k.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(k => k.Descricao).HasColumnType("VARCHAR(60)");
            builder.Property(k => k.Valor).IsRequired();
            builder.Property(k => k.TipoProduto).HasConversion<string>();
        }
    }
}
