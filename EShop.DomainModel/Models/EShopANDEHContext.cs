using EShop.DomainModel.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.DomainModel.Models
{
    public class EShopANDEHContext : DbContext
    {
        public EShopANDEHContext(DbContextOptions<EShopANDEHContext> options): base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFeature> CategoryFeature { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductKeyword> ProductKeywords { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Feature>(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration<Orders>(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
            modelBuilder.ApplyConfiguration<KeyWord>(new KeyWordConfiguration());
            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
