using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DomainModel.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
            builder.HasKey(x => x.CategoryID);
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Childrens).WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentID).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x=> x.ParentID).IsRequired(false);
        }
    }
}
