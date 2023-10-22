using EShop.DomainModel.BussinessModel.Supplier;
using EShop.DomainModel.Models;
using EShopANDEH.ApplicationServiceContract.Services;
using EShopANDEH.DataAccessServiceContract.Repositories;
using FrameWork.DTOS;

namespace EShopANDEH.Application
{
    public class SupplierApplication : ISupplierApplication
    {
        private readonly ISupplierRepository repo;
        public SupplierApplication(ISupplierRepository repo)
        {
            this.repo = repo;
        }
        public SupplierAddModel Get(int SupplierID)
        {
            var res = repo.GetbyId(SupplierID);
            SupplierAddModel result = new SupplierAddModel 
            {
                SupplierDescription = res.SupplierDescription,
                SupplierName = res.SupplierName, 
                SupplierID = res.SupplierID
            };
            return result;
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public OperationResult Register(SupplierAddModel supplierAddModel)
        {
            OperationResult op = new OperationResult("Add Supplier");
            try
            {
                if (repo.ExistSupplierName(supplierAddModel.SupplierName))
                {
                    return op.ToFail("Supplier Name already is Exsists");
                }
                Supplier suplier = new Supplier
                {
                    SupplierDescription = supplierAddModel.SupplierName,
                    SupplierName = supplierAddModel.SupplierName,
                };
                op = repo.Regester(suplier);
                return op;

            }
            catch (Exception ex) { return op.ToFail("Supplier Registerion is Failed" + ex.Message); }

            }

        public OperationResult Remove(int SupplierID)
        {
            if(repo.HasRelatedSupplier(SupplierID))
            {
                return new OperationResult("Remove Supplier",SupplierID).ToFail("Supplier Has Related Product");

            }
            return repo.Remove(SupplierID);
        }

        public OperationResult Update(SupplierAddModel supplierAddModel)
        {
            Supplier suplier = new Supplier
            {
                SupplierDescription = supplierAddModel.SupplierDescription,
                SupplierID = supplierAddModel.SupplierID,
                SupplierName = supplierAddModel.SupplierName,
            };
            return repo.Update(suplier);
        }
    }
}
