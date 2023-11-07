using EShop.DomainModel.BussinessModel.Product;
using EShop.DomainModel.Models;
using EShopANDEH.DataAccessServiceContract.Repositories;
using FrameWork.BaseRepositories;
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
            OperationResult result = new(" Assing Category Feature to Product Afert Regsiteration ");
            try
            {
                var product = DB.Products.FirstOrDefault(x => x.ProductID == ProductID);
                var category = DB.Categories.FirstOrDefault(x => x.CategoryID == product.CategoryID);
                var categoryfeature = category.CategoryFeatures.ToList();
                foreach (CategoryFeature item in categoryfeature)
                {
                    ProductFeature productfeature = new ProductFeature{ 
                        EffectOnUnitPrice =0,
                        FeatureID = item.FeatureID,
                        FeatureValue = String.Empty,
                        ProductID= ProductID,
                    };
                    DB.ProductFeatures.Add(productfeature);
                }
                DB.SaveChanges();
                return result.ToSuccess("Assing Category Feature to Product Afert Regsiteration Successflly");
            }
            catch (Exception ex)
            {

                return result.ToFail(" Assing Category Feature to Product Afert Regsiteration Faild ");
            }
        }

        public OperationResult AssingFeatureValueSpecificProductandFeatrue(FeatureValueAddModel fp)
        {
            OperationResult result = new OperationResult("AssignCategoryFeatureToProductAfterRegistration");

            try
            {

                var productfeatures = DB.ProductFeatures.FirstOrDefault(
                    f => f.FeatureID == fp.FeatrueID && f.ProductID == fp.ProductID);

                productfeatures.EffectOnUnitPrice = fp.EfEffectOnPrice;
                productfeatures.FeatureValue = fp.FeatureValue;
                DB.SaveChanges();   
                return result.ToSuccess("Feature Assigned");
            }
            catch (Exception ex)
            {

                return result.ToFail("Feature Assignment Failed");
            }
        }

        public OperationResult AssingKeyWordToProduct(int keywordID, int ProductID)
        {
            OperationResult result = new("Assing KeyWord to PRoduct ");
            try
            {
                DB.ProductKeywords.Add(new ProductKeyword { 
                    ProductID = ProductID,
                    KeywordID = keywordID
                });
                DB.SaveChanges();
                return result.ToSuccess("KeyWOrd Assinged");
            }
            catch (Exception ex)
            {

                return result.ToFail("Feature Keyword Failed");
            }
        }

        public OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID)
        {
            OperationResult result = new OperationResult("Remove KeyWord From Product");
            try
            {
                DB.ProductKeywords
                    .Remove(DB.ProductKeywords
                    .FirstOrDefault(x=> x.KeywordID == KeyWordID && x.ProductID == ProductID));
                DB.SaveChanges();
                return result.ToSuccess("Product keyword removed Successfully");

            }
            catch (Exception ex)
            {

                return result.ToFail("Product Remove Faild " + ex.Message);
            }
        }

        public bool ExistFeature(string FeatureName)
        {
            return DB.Features.Any(x=> x.FeatureName == FeatureName);
        }

        public bool ExistKeyWord(string keyWord)
        {
            return DB.KeyWords.Any(x=> x.KeywordText == keyWord);
        }

        public bool ExistProductKey(int ProductId, int KeyWord)
        {
            return DB.ProductKeywords.Any(x => x.ProductID == ProductId && x.KeywordID == KeyWord);
        }

        public bool ExistProductName(string productName)
        {
            return DB.Products.Any(x=> x.ProductName == productName);
        }

        public bool ExistProductNameForAnotherPRoduct(string productName, int ProductID)
        {
            return DB.Products.Any(x=> x.ProductID!=ProductID && x.ProductName == productName);
        }

        public bool ExistSlug(string slug)
        {
            return DB.Products.Any(p => p.Slug == slug);
        }

        public bool ExistSlugForAnotherProduct(string slug,int ProductID)
        {
           return DB.Products.Any(p => p.ProductID != ProductID && p.Slug == slug );
        }

        public List<Product> GetAll()
        {
            return DB.Products.ToList();
        }

        public Product GetbyId(int id)
        {
            return DB.Products.FirstOrDefault(x=> x.ProductID == id);
        }

        public OperationResult Regester(Product curent)
        {
            OperationResult result = new OperationResult("Register Product");
            try
            {
                DB.Products.Add(curent);
                DB.SaveChanges();
                return result.ToSuccess("Register Product Successfully" ,curent.ProductID);
            }
            catch (Exception ex)
            {

                return result.ToFail("Faild to Register Product");
            }
        }

        public OperationResult RegisterFeatureAndAssingItToTheProduct(ProductFeatrueAddModel pf)
        {
            OperationResult resualt = new OperationResult("Register Featuer and Assing to Product ");
            try
            {
                var featureRegister = new Feature
                {
                    FeatureName = pf.FeatureName,
                };
                DB.Features.Add(featureRegister);
                DB.SaveChanges();
                var productFeautre = new ProductFeature
                {
                    EffectOnUnitPrice = pf.EffectOnPrice,
                    FeatureID = featureRegister.FeatureID,
                    FeatureValue = pf.FeatureValue,
                    ProductID = pf.ProductId,
                };
                DB.SaveChanges();
                return resualt.ToSuccess("Register Featuer and Assing to Product  is Successfully", pf.ProductId);
            }
            catch (Exception ex)
            {

                return resualt.ToFail("Faild to Register Featuer and Assing to Product " + ex.Message);
            }
        }

        public OperationResult RegisterKeyWordAndAassingItToTheProduct(string KeyWord, int productID)
        {
            OperationResult result = new OperationResult("Register Keyword and Assing it to Prodauct");
            try
            {
                var KeyWordRegsiter = new KeyWord { KeywordText = KeyWord };
                DB.KeyWords.Add(KeyWordRegsiter);
                DB.SaveChanges();
                DB.ProductKeywords.Add(
                    new ProductKeyword
                    {
                        KeywordID = KeyWordRegsiter.KeywordID,
                        ProductID = productID
                    });
                DB.SaveChanges();
                return result.ToSuccess(" Keyword Successfully Assinged");
            }
            catch (Exception ex)
            {

                return result.ToFail("Register Keyword Failed"+ex.Message);
            }



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
                return result.ToSuccess("Remove Product Successfully", id);
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

        List<ProdutSearchModel> IBaseReposetorySearchable<Product, int, ProdutSearchModel, ProductListItem>.Search(ProdutSearchModel s, out int RecordCount)
        {
            throw new NotImplementedException();
        }
    }
}
