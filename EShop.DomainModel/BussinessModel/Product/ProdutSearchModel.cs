using FrameWork.DTOS;

namespace EShop.DomainModel.BussinessModel.Product
{
    public class ProdutSearchModel : PageModel
    {
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }

        public int? UnitPriceFrom { get; set;}
        public int? UnitPriceTo { get; set; }
        public string ProductName { get; set; }
    }
}
