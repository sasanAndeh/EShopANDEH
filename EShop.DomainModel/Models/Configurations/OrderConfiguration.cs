using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DomainModel.Models.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x => x.OrderID);
            builder.Property(x => x.AddressID)
                .IsRequired();
            builder.Property(x => x.OrderDescription)
                .HasMaxLength(500);
            builder.Property(x => x.OrderDate)
                .IsRequired().HasDefaultValue(DateTime.Now);
        
            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Orders)
                .HasForeignKey(x => x.OrderID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
