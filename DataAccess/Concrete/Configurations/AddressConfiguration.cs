using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class AddressConfiguration : BaseConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        builder.Property(x => x.street).IsRequired();
        builder.Property(x => x.City).IsRequired();
        builder.Property(x => x.Country).IsRequired();
        builder.Property(x => x.PostalCode).IsRequired();
        builder.Property(x => x.FullAddress).IsRequired();
    }
}