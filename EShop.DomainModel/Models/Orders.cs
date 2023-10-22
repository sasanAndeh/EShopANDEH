namespace EShop.DomainModel.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        public string OrderDescription { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Orders()
        {
            this.OrderDetails = new List<OrderDetails>();
        }
    }
}
