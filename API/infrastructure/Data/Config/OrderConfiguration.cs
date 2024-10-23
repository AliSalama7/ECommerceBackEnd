using Core.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(order => order.ShipToAddress, address => { address.WithOwner(); });
            builder.Navigation(order => order.ShipToAddress).IsRequired();
            builder.Property(order => order.Status).HasConversion(status => status.ToString()
            ,status => (OrderStatus)Enum.Parse(typeof(OrderStatus), status));    
            builder.HasMany(order => order.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
