namespace EShop.DomainModel.BussinessModel.Product
{
    public class FeatureValueAddModel
    {
        public int ProductID
        {
            get; set;
        }

        public int FeatrueID
        {
            get; set;
        }
        public string FeatureValue
        {
            get; set;
        }
        public int EfEffectOnPrice
        {
            get; set;
        }
    }
}
