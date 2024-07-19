using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Order
    {
        [Key]
        public required string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? OrderStatus { get; set; }
        public int? AccountId { get; set; }
        public virtual Account? Account { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
