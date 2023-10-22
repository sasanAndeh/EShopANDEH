using EShop.DomainModel.Models;
using EShopANDEH.DataAccessServiceContract.Repositories;
using FrameWork.DTOS;

namespace DataAccess.EShopANDEH.EFCore
{
    public class SupplierRepsitory : ISupplierRepository
    {
        private readonly EShopANDEHContext DB;
        public SupplierRepsitory(EShopANDEHContext db)
        {
            this.DB = db;
        }

        public bool HasRelatedSupplier(int SupplierID)
        {
            var resualt = DB.Suppliers.FirstOrDefault(x=> x.SupplierID == SupplierID);
            return resualt.Products.Any();
        }
        public bool ExistSupplierName(string supplierName)
        {
            return DB.Suppliers.Any(x => x.SupplierName == supplierName);
        }

        public List<Supplier> GetAll()
        {
            return DB.Suppliers.ToList();
        }

        public Supplier GetbyId(int id)
        {
            return DB.Suppliers.FirstOrDefault(x=> x.SupplierID == id);
        }

        public OperationResult Regester(Supplier curent)
        {
           OperationResult op = new OperationResult("Add Supplier");
            try
            {
                DB.Suppliers.Add(curent);
                DB.SaveChanges();
                return  op.ToSuccess("Register Supplier successfully",curent.SupplierID);
            }catch (Exception ex)
            {
                return op.ToFail("Register Supplier Failed " + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Supplier");
            try
            {
                var sp = GetbyId(id);
                DB.Suppliers.Remove(sp); 
                DB.SaveChanges();
                return op.ToSuccess("Delete Supplier successfully", id);
            }
            catch (Exception ex)
            {
                return op.ToFail("Delete Supplier Failed " + ex.Message);
            }
        }

        public OperationResult Update(Supplier curent)
        {
            OperationResult op = new OperationResult("Update Supplier");
            try
            {
                var old = GetbyId(curent.SupplierID);
                old.SupplierName = curent.SupplierName;
                old.SupplierDescription = curent.SupplierDescription;
                DB.SaveChanges();
                return op.ToSuccess("Update Supplier successfully", curent.SupplierID);
            }
            catch (Exception ex)
            {
                return op.ToFail("Update Supplier Failed " + ex.Message);
            }
        }
    }
}
