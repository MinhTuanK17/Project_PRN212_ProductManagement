using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.OrderId).HasMaxLength(7);
            builder.Property(o => o.OrderStatus).HasMaxLength(50);
            builder.HasCheckConstraint("CK_Order_Status", "[OrderStatus] = 'Pending' OR [OrderStatus] = 'Confirmed' OR [OrderStatus] = 'Cancelled'");
            builder.HasData(
                new Order
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Confirmed",
                    AccountId = 4
                },
                new Order
                {
                    OrderId = 2,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Pending",
                    AccountId = 10
                },
                new Order
                {
                    OrderId = 3,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Cancelled",
                    AccountId = 4
                },
                new Order
                {
                    OrderId = 4,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Confirmed",
                    AccountId = 9
                },
                new Order
                {
                    OrderId = 5,
                    OrderDate = new DateTime(2024, 7, 14),
                    OrderStatus = "Pending",
                    AccountId = 8
                },
                new Order
                {
                    OrderId = 6,
                    OrderDate = new DateTime(2024, 7, 15),
                    OrderStatus = "Confirmed",
                    AccountId = 4
                }
            );
        }
    }
}
