using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DomainModel.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.PageTitle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(100);
            builder.Property(x=> x.JSONLDInformation).IsRequired().HasMaxLength(4000);
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(320);
            builder.Property(x => x.MetaKeyWord).IsRequired().HasMaxLength(160);
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(400);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(400);
            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Product)
                .HasForeignKey(x=>x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ProductFeatures)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ProductKeywords)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
