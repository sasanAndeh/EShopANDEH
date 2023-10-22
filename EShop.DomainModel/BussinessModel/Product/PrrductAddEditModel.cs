namespace EShop.DomainModel.BussinessModel.Product
{
    public class PrrductAddEditModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public long Unitprice { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public string JSONLDInformation { get; set; }
        public string ImageUrl { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
    }
}
