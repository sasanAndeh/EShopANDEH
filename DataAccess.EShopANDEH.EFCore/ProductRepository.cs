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

            OperationResult result = new OperationResult("Remove Product");
            try
            {
                var product = DB.Products.FirstOrDefault(x => x.ProductID == id);
                var productFeature = product.ProductFeatures.ToList();
                foreach (var feature in productFeature)
                    DB.ProductFeatures.Remove(feature);


                var productKeyword = product.ProductKeywords.ToList();
                foreach (var item in productKeyword)
                    DB.ProductKeywords.Remove(item);

                DB.SaveChanges();
                DB.Products.Remove(product);
                DB.SaveChanges();
                return result.ToSuccess("Remove Product Successflly", id);
            }
            catch (Exception ex)
            {

                return result.ToFail("Remove Product Failed" + ex.Message);    
            }
            

        }

        public List<ProductListItem> Search(ProdutSearchModel searchModel, out int RecordCount)
        {
            var query = from product in DB.Products select product;
            if (!string.IsNullOrEmpty(searchModel.ProductName))
                query = query.Where(x => x.ProductName.StartsWith(searchModel.ProductName));
            if (!string.IsNullOrEmpty(searchModel.Slug))
                query = query.Where(x => x.Slug.StartsWith(searchModel.Slug));
            if (searchModel.CategoryID != null)
                query = query.Where(x => x.CategoryID == searchModel.CategoryID);
            if (searchModel.SupplierID != null)
                query = query.Where(x => x.SupplierID == searchModel.SupplierID);
            if (searchModel.UnitPriceFrom != null)
                query = query.Where(x => x.Unitprice >= searchModel.UnitPriceFrom);
            if (searchModel.UnitPriceTo != null)
                query = query.Where(x => x.Unitprice <= searchModel.UnitPriceTo);

            RecordCount = query.Count();
            query = query.OrderByDescending(x=> x.ProductID)
                .Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            var query2 = from item in query select new ProductListItem
            {
                CategoryName = item.Category.CategoryName,
                HasRealtedOrder = item.OrderDetails.Any(),
                SupplierName = item.Supplier.SupplierName,
                ProductID = item.ProductID,
                ProductName = item.ProductName,
                Slug = item.Slug,
                UnitPrice = item.Unitprice,
            };
            return query2.ToList();


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

                return result.ToFail("Product Update Failed" + ex.Message);
            }

        }
    }
}
