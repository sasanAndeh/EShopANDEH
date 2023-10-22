using System.ComponentModel.DataAnnotations;

namespace EShop.DomainModel.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please Enter ProductName")]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "Product Name Must be between 3 and 100")]
        public string ProductName { get; set; }
        [Range(1000,10000000000,ErrorMessage ="ivalid Unit Price")]
        public long Unitprice { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="Plase Enter Slug")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="Slug Must be Between 3 and 100")]
        public string Slug { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public string JSONLDInformation { get; set; }
        public string ImageUrl { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<ProductKeyword> ProductKeywords { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Product()
        {
            this.ProductKeywords = new List<ProductKeyword>();
            this.ProductFeatures = new List<ProductFeature>();
            this.OrderDetails = new List<OrderDetails>();
        }

    }
}
