namespace EShop.DomainModel.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int? ParentID { get; set; }
        public string LineAge { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Childrens  { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }

        public Category() 
        {
            this.Products = new List<Product>();
            this.Categories = new List<CategoryFeature>();
            this.Childrens = new List<Category>();
        }
    }
}
