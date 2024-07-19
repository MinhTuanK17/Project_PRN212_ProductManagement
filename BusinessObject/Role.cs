using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public virtual ICollection<Account>? Account { get; set; }
    }
}
