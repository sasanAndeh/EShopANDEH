using EShop.DomainModel.BussinessModel.Supplier;
using EShop.DomainModel.Models;
using FrameWork.DTOS;

namespace EShopANDEH.ApplicationServiceContract.Services
{
    public interface ISupplierApplication
    {
        OperationResult Register(SupplierAddModel supplierAddModel);
        OperationResult Remove(int SupplierID);
        OperationResult Update(SupplierAddModel supplierAddModel);
        List<Supplier> GetAll();
        SupplierAddModel Get(int SupplierID);
    }
}
