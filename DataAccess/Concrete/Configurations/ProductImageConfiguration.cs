using System;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStack;

namespace DataAccess.Concrete.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Url).IsRequired();
        
    }
}