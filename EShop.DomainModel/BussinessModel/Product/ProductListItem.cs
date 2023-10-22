namespace EShop.DomainModel.BussinessModel.Product
{
    public class ProductListItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public bool HasRealtedName { get; set; }
        public long  UnitPrice { get; set; }
        public string Slug { get; set; }

    }
}
