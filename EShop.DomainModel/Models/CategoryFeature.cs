namespace EShop.DomainModel.Models
{
    public class CategoryFeature
    {
        public int CategoryFeatureID { get; set; }
        public int CategoryID { get; set; }
        public int FeatureID { get; set; }
        public Category Category { get; set; }
        public Feature Feature { get; set; }

    }
}
