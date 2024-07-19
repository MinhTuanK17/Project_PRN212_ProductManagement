using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public virtual ICollection<Product>? Product { get; set; }
    }
}
