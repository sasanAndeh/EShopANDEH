namespace EShop.DomainModel.Models
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public ICollection<CategoryFeature> CategoryFeature { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public Feature()
        {
            this.CategoryFeature = new List<CategoryFeature>();
            this.ProductFeatures = new List<ProductFeature>();

        }
    }
}
