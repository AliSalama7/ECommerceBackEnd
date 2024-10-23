using Core.Models.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPaymentIntentIdSpecification : Specification<Order>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId)
            :base(o => o.PaymentIntentId == paymentIntentId)
        {
            
        }
    }
}
