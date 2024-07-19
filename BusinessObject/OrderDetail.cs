using Microsoft.EntityFrameworkCore;

namespace BusinessObject
{
    [PrimaryKey(nameof(OrderId), nameof(ProductPhoneId))]
    public class OrderDetail
    {
        public string OrderId { get; set; }
        public string ProductPhoneId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
