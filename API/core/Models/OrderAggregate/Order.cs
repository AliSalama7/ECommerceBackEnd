namespace Core.Models.OrderAggregate
{
    public class Order : BaseModel
    {
        public Order()
        {
            
        }
        public Order(List<OrderItem> orderItems,string buyerEmail,OAddress shipToAddress,
            DeliveryMethod deliveryMethod,decimal subtotal,string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
            OrderItems = orderItems;
            PaymentIntentId = paymentIntentId;
        }
        public string BuyerEmail {  get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OAddress ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderItem> OrderItems { get; set;}
        public decimal Subtotal {  get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId {  get; set; }
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}
