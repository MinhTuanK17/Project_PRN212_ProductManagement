using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.FullName).HasMaxLength(100);
            builder.Property(a => a.PhoneNumber).HasMaxLength(13);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Password).IsRequired();
            builder.HasData(
                new Account
                {
                    AccountId = 1,
                    FullName = "Nguyễn Minh Tuấn",
                    Address = "Quảng Bình",
                    Gender = true,
                    DayOfBirth = new DateTime(2003, 11, 23),
                    PhoneNumber = "0941673660",
                    Email = "tuannm23.dev@gmail.com",
                    Password = "1231234",
                    RoleId = 2
                },
                new Account
                {
                    AccountId = 2,
                    FullName = "Phan Thị Trà My",
                    Address = "Quảng Nam",
                    Gender = false,
                    DayOfBirth = new DateTime(2003, 07, 17),
                    PhoneNumber = "012345678",
                    Email = "tramy123@gmail.com",
                    Password = "123qwe",
                    RoleId = 2
                },
                new Account
                {
                    AccountId = 3,
                    FullName = "Trương Vĩnh Thịnh",
                    Address = "Quảng Nam",
                    Gender = true,
                    DayOfBirth = new DateTime(2003, 01, 10),
                    PhoneNumber = "0987651431",
                    Email = "vinhthinh321@gmail.com",
                    Password = "123456",
                    RoleId = 2
                },
                new Account
                {
                    AccountId = 4,
                    FullName = "Nguyễn Thanh Hải",
                    Address = "Hà Nội",
                    Gender = true,
                    DayOfBirth = new DateTime(1995, 05, 20),
                    PhoneNumber = "0978123456",
                    Email = "thanhhai456@gmail.com",
                    Password = "abcdef",
                    RoleId = 1
                },
                new Account
                {
                    AccountId = 5,
                    FullName = "Phạm Thị Mai",
                    Address = "Đà Nẵng",
                    Gender = false,
                    DayOfBirth = new DateTime(1988, 11, 15),
                    PhoneNumber = "0967123123",
                    Email = "maipham88@gmail.com",
                    Password = "xyz789",
                    RoleId = 1
                },
                new Account
                {
                    AccountId = 6,
                    FullName = "Trần Thị Hoa",
                    Address = "Hồ Chí Minh",
                    Gender = false,
                    DayOfBirth = new DateTime(1990, 07, 25),
                    PhoneNumber = "0909123456",
                    Email = "hoatran90@gmail.com",
                    Password = "qwerty",
                    RoleId = 1
                },
                new Account
                {
                    AccountId = 7,
                    FullName = "Lê Văn Tâm",
                    Address = "Bình Dương",
                    Gender = true,
                    DayOfBirth = new DateTime(1987, 03, 18),
                    PhoneNumber = "0918234567",
                    Email = "tamle87@gmail.com",
                    Password = "pass123",
                    RoleId = 1
                },
                new Account
                {
                    AccountId = 8,
                    FullName = "Nguyễn Thị Ngọc Trâm",
                    Address = "Vĩnh Long",
                    Gender = false,
                    DayOfBirth = new DateTime(1993, 12, 10),
                    PhoneNumber = "0987123456",
                    Email = "tramnguyen93@gmail.com",
                    Password = "abc123",
                    RoleId = 1
                },
                new Account
                {
                    AccountId = 9,
                    FullName = "Phan Văn Đức",
                    Address = "Đắk Lắk",
                    Gender = true,
                    DayOfBirth = new DateTime(1985, 09, 08),
                    PhoneNumber = "0978123456",
                    Email = "ducphan85@gmail.com",
                    Password = "abcd123",
                    RoleId = 1
                },
                new Account
                {
                    AccountId = 10,
                    FullName = "Nguyễn Thị Bình",
                    Address = "Bắc Giang",
                    Gender = false,
                    DayOfBirth = new DateTime(1996, 06, 17),
                    PhoneNumber = "0987123123",
                    Email = "binhnguyen96@gmail.com",
                    Password = "pass456",
                    RoleId = 1
                }
            );
        }
    }
}
