using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DomainModel.Models.Configurations
{
    public class KeyWordConfiguration : IEntityTypeConfiguration<KeyWord>
    {
        public void Configure(EntityTypeBuilder<KeyWord> builder)
        {
            builder.HasMany(x => x.ProductKeywords)
                .WithOne(x => x.KeyWord)
                .HasForeignKey(x => x.KeywordID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.KeywordText).HasMaxLength(100);
            builder.HasKey(x => x.KeywordID);
        }
    }
}
