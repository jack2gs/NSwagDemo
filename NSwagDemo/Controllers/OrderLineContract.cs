namespace NSwagDemo.Controllers
{
    public class OrderLineContract
    {
        public int Id { get; }

        public int OrderId { get; }

        public int ProductId { get; }

        public decimal Price { get; }

        public int Quantity { get; }

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
