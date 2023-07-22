using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        builder.Property(x => x.Street).IsRequired().HasMaxLength(35);
        builder.Property(x => x.City).IsRequired().HasMaxLength(35);
        builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
        builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(10);
        builder.Property(x => x.FullAddress).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(20);
    }
}