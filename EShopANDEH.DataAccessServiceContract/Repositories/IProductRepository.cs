using EShop.DomainModel.BussinessModel.Product;
using EShop.DomainModel.Models;
using FrameWork.BaseRepositories;
using FrameWork.DTOS;

namespace EShopANDEH.DataAccessServiceContract.Repositories
{
    public interface IProductRepository : IBaseReposetorySearchable<Product,int,ProdutSearchModel,ProductListItem>
    {
        bool ExistProductName(string productName);
        bool ExistProductNameForAnotherPRoduct(string productName,int ProductID);
        bool ExistSlug(string slug);
        bool ExistSlugForAnotherProduct(string slug,int ProductID);
        bool ExistProductKey(int ProductId, int KeyWord);
        bool ExistKeyWord(string keyWord);
        bool ExistFeature(string FeatureName);
        OperationResult AssingKeyWordToProduct(int keyWord,int ProductID);
        OperationResult RegisterKeyWordAndAassingItToTheProduct(string keyWord,int ProductID);
        OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID);
        OperationResult AssingCategoryFeatureToProductAfterRegistration(int ProductID);
        OperationResult AssingFeatureValueSpecificProductandFeatrue(int ProductID,int FeatrueID , string FeatureName);
        OperationResult RegisterFeatureAndAssingItToTheProduct(ProductFeatrueAddModel pf);

    }
}
