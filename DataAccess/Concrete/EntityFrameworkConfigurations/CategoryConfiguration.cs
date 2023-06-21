using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFrameworkConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(c => c.CategoryId);
        
        builder.Property(c=> c.CategoryId).HasColumnName("category_id");

        builder.Property(c => c.CategoryName).HasColumnName("category_name").IsRequired();

        builder.Property(c => c.Description).HasColumnName("description");

    }
}

