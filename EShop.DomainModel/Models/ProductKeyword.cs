namespace EShop.DomainModel.Models
{
    public class ProductKeyword
    {
        public int ProductKeywordID { get; set; }
        public  int ProductID { get; set; }
        public  int KeywordID { get; set; }
        public KeyWord KeyWord { get; set; }
        public Product Product { get; set; }

    }
}
