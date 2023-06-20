using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameworkConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products").HasKey(p => p.ProductId);
        builder.Property(p => p.ProductId).HasColumnName("product_id");
        builder.Property(p => p.CategoryId).HasColumnName("category_id");
        builder.Property(p => p.UnitsInStock).HasColumnName("units_in_stock");
        builder.Property(p => p.UnitPrice).HasColumnName("unit_price");
        builder.Property(p => p.ProductName).HasColumnName("product_name");
    }
}

