namespace EShop.DomainModel.Models
{
    public class KeyWord
    {
        public int KeywordID { get; set; }
        public string KeywordText { get; set; }
        public  ICollection<ProductKeyword> ProductKeywords { get; set; }
        public KeyWord()
        {
            this.ProductKeywords = new List<ProductKeyword>();

        }
    }
}
