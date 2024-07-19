using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.RoleName).IsRequired().HasMaxLength(50);
            builder.HasData(
                new Role { RoleId = 1, RoleName = "Customer" },
                new Role { RoleId = 2, RoleName = "Staff" },
                new Role { RoleId = 3, RoleName = "Administrator" },
                new Role { RoleId = 4, RoleName = "Locked Account" }
            );
        }
    }
}
