using System;
using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStack;

namespace DataAccess.Concrete.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Slug).IsRequired();
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.BaseImageUrl).IsRequired();

        builder
            .HasMany(x => x.Images)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}