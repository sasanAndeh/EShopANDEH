using EShop.DomainModel.BussinessModel.Product;
using EShop.DomainModel.Models;
using EShopANDEH.DataAccessServiceContract.Repositories;
using FrameWork.DTOS;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EShopANDEH.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly EShopANDEHContext DB;

        public ProductRepository(EShopANDEHContext DB)
        {
            this.DB = DB;
        }
        public OperationResult AssingCategoryFeatureToProductAfterRegistration(int ProductID)
        {
            throw new NotImplementedException();
        }

        public OperationResult AssingFeatureValueSpecificProductandFeatrue(int ProductID, int FeatrueID, string FeatureName)
        {
            throw new NotImplementedException();
        }

        public OperationResult AssingKeyWordToProduct(int keyWord, int ProductID)
        {
            throw new NotImplementedException();
        }

        public OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID)
        {
            throw new NotImplementedException();
        }

        public bool ExistFeature(string FeatureName)
        {
            throw new NotImplementedException();
        }

        public bool ExistKeyWord(string keyWord)
        {
            throw new NotImplementedException();
        }

        public bool ExistProductKey(int ProductId, int KeyWord)
        {
            throw new NotImplementedException();
        }

        public bool ExistProductName(string productName)
        {
            throw new NotImplementedException();
        }

        public bool ExistProductNameForAnotherPRoduct(string productName, int ProductID)
        {
            throw new NotImplementedException();
        }

        public bool ExistSlug(string slug)
        {
            throw new NotImplementedException();
        }

        public bool ExistSlugForAnotherProduct(string slug)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Regester(Product curent)
        {
            throw new NotImplementedException();
        }

        public OperationResult RegisterFeatureAndAssingItToTheProduct(ProductFeatrueAddModel pf)
        {
            throw new NotImplementedException();
        }

        public OperationResult RegisterKeyWordAndAassingItToTheProduct(string keyWord, int ProductID)
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(int id)
        {
            throw new NotImplementedException();
        }

        public ProductListItem Search(ProdutSearchModel s, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(Product curent)
        {
            OperationResult result = new OperationResult("Update " + this.GetType().Name, curent.ProductID);
            try
            {
                DB.Products.Attach(curent);
                DB.Entry<Product>(curent).State = EntityState.Modified;
                DB.SaveChanges();
                return result.ToSuccess("Product Updated Successfully", curent.ProductID);
            }

            catch (Exception ex)
            {

                return result.ToFail("Product Update Failed"+ex.Message);
            }

        }
    }
}
