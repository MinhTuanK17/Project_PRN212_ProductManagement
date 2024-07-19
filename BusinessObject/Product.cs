using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Product
    {
        [Key]
        public required string ProductPhoneId { get; set; }
        public required string ProductPhoneName { get; set; }
        public required decimal PhonePrice { get; set; }
        public required int PhoneQuantity { get; set; }
        public string? RamPhone { get; set; }
        public string? MemoryPhone { get; set; }
        public string? PhoneDescription { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
