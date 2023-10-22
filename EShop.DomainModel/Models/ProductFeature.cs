namespace EShop.DomainModel.Models
{
    public class ProductFeature
    {
        public int ProductFeatureID { get; set; }
        public int ProductID { get; set; }
        public int FeatureID { get; set; }
        public int EffectOnUnitPrice { get; set; }
        public string FeatureValue { get; set; }
        public Feature Feature { get; set; }
        public Product Product { get; set; }

    }
}
