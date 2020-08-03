namespace NSwagDemo.Controllers
{
    public class OrderLineContract
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public OrderLineContract(int id, int orderId, int productId, decimal price, int quantity)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public OrderLineContract()
        {

        }
    }
}
