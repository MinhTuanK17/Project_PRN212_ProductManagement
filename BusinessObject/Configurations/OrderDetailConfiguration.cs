using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(od => od.TotalPrice).HasColumnType("money");
            builder.HasData(
                new OrderDetail
                {
                    OrderId = 1,
                    ProductPhoneId = "P1001",
                    Quantity = 2,
                    TotalPrice = 69998m
                },
                new OrderDetail
                {
                    OrderId = 1,
                    ProductPhoneId = "P2002",
                    Quantity = 1,
                    TotalPrice = 20459m
                },
                new OrderDetail
                {
                    OrderId = 2,
                    ProductPhoneId = "P3001",
                    Quantity = 3,
                    TotalPrice = 44997m
                },
                new OrderDetail
                {
                    OrderId = 3,
                    ProductPhoneId = "P4003",
                    Quantity = 1,
                    TotalPrice = 41990m
                },
                new OrderDetail
                {
                    OrderId = 4,
                    ProductPhoneId = "P5003",
                    Quantity = 4,
                    TotalPrice = 79996m
                },
                new OrderDetail
                {
                    OrderId = 5,
                    ProductPhoneId = "P1003",
                    Quantity = 3,
                    TotalPrice = 51000m
                },
                new OrderDetail
                {
                    OrderId = 6,
                    ProductPhoneId = "P2001",
                    Quantity = 2,
                    TotalPrice = 59998m
                }
            );
        }
    }
}
