using System.ComponentModel.DataAnnotations;

namespace EShop.DomainModel.BussinessModel.Supplier
{
    public class SupplierEditModel
    {
        public int SupplierID { get; set; }
        [Required(ErrorMessage ="لطفا نام فراهم کننده را وارد کنید.")]
        [StringLength(50,ErrorMessage ="نام باید بین 3 تا 50 باشد.")]
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
    }
}
 