using EShop.DomainModel.Models;
using FrameWork.BaseRepositories;

namespace EShopANDEH.DataAccessServiceContract.Repositories
{
    public interface ISupplierRepository : IBaseRepository<Supplier, int>
    {
         bool ExistSupplierName(string SupplierName);
        bool HasRelatedSupplier(int SupplierID);
    }
} 
