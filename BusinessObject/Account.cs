using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int? RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Order>? Order { get; set; }

    }
}
