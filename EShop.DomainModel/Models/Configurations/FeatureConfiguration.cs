using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DomainModel.Models.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasMany(x => x.CategoryFeature).WithOne(x => x.Feature)
                .HasForeignKey(x => x.FeatureID).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.FeatureName).IsRequired().HasMaxLength(256);
            // builder.HasKey(x => x.FeatureID);
            //builder.ToTable("");
        }
    }
}
