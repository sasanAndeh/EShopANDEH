using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DomainModel.Models.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.SupplierName).IsRequired();
            builder.Property(x => x.SupplierDescription).HasMaxLength(500);
            builder.HasMany(x=> x.Products).WithOne(x => x.Supplier)
                .HasForeignKey(x=> x.SupplierID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
