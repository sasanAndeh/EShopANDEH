namespace EShop.DomainModel.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string  SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public ICollection<Product> Products { get; set; }
        public Supplier()
        {
            this.Products = new List<Product>();
        }
    }
}
