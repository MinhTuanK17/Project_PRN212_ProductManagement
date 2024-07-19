using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductPhoneId = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ProductPhoneName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhonePrice = table.Column<decimal>(type: "money", nullable: false),
                    PhoneQuantity = table.Column<int>(type: "int", nullable: false),
                    RamPhone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    MemoryPhone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    PhoneDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductPhoneId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    DayOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.CheckConstraint("CK_Order_Status", "[OrderStatus] = 'Pending' OR [OrderStatus] = 'Confirmed' OR [OrderStatus] = 'Cancelled'");
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    ProductPhoneId = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductPhoneId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductPhoneId",
                        column: x => x.ProductPhoneId,
                        principalTable: "Products",
                        principalColumn: "ProductPhoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Iphone" },
                    { 2, "Samsung" },
                    { 3, "Xiaomi" },
                    { 4, "Oppo" },
                    { 5, "Sony" },
                    { 6, "Realme" },
                    { 7, "VSmart" },
                    { 8, "Vivo" },
                    { 9, "One Plus" },
                    { 10, "Nokia" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Customer" },
                    { 2, "Staff" },
                    { 3, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Address", "DayOfBirth", "Email", "FullName", "Gender", "Password", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, "Quảng Bình", new DateTime(2003, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "tuannm23.dev@gmail.com", "Nguyễn Minh Tuấn", true, "1231234", "0941673660", 2 },
                    { 2, "Quảng Nam", new DateTime(2003, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "tramy123@gmail.com", "Phan Thị Trà My", false, "123qwe", "012345678", 2 },
                    { 3, "Quảng Nam", new DateTime(2003, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "vinhthinh321@gmail.com", "Trương Vĩnh Thịnh", true, "123456", "0987651431", 2 },
                    { 4, "Hà Nội", new DateTime(1995, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "thanhhai456@gmail.com", "Nguyễn Thanh Hải", true, "abcdef", "0978123456", 1 },
                    { 5, "Đà Nẵng", new DateTime(1988, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maipham88@gmail.com", "Phạm Thị Mai", false, "xyz789", "0967123123", 1 },
                    { 6, "Hồ Chí Minh", new DateTime(1990, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoatran90@gmail.com", "Trần Thị Hoa", false, "qwerty", "0909123456", 1 },
                    { 7, "Bình Dương", new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "tamle87@gmail.com", "Lê Văn Tâm", true, "pass123", "0918234567", 1 },
                    { 8, "Vĩnh Long", new DateTime(1993, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "tramnguyen93@gmail.com", "Nguyễn Thị Ngọc Trâm", false, "abc123", "0987123456", 1 },
                    { 9, "Đắk Lắk", new DateTime(1985, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ducphan85@gmail.com", "Phan Văn Đức", true, "abcd123", "0978123456", 1 },
                    { 10, "Bắc Giang", new DateTime(1996, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "binhnguyen96@gmail.com", "Nguyễn Thị Bình", false, "pass456", "0987123123", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductPhoneId", "CategoryId", "MemoryPhone", "PhoneDescription", "PhonePrice", "PhoneQuantity", "ProductPhoneName", "RamPhone" },
                values: new object[,]
                {
                    { "P10001", 10, "512 GB", "The Nokia X20 combines durability and performance with its 6.67-inch Full HD+ display, Snapdragon 480 5G processor, and quad-camera setup.", 15999m, 60, "Nokia X20", "12 GB" },
                    { "P10002", 10, "256 GB", "The Nokia G50 is an affordable 5G smartphone featuring a 6.82-inch HD+ display, Snapdragon 480 5G processor, and a triple-camera system.", 12999m, 80, "Nokia G50", "12 GB" },
                    { "P10003", 10, "512 GB", "The Nokia 8.3 5G offers a premium experience with its 6.81-inch PureDisplay, Snapdragon 765G processor, and quad-camera system with ZEISS optics. It is designed for users who want cutting-edge technology and superior camera capabilities.", 22999m, 50, "Nokia 8.3 5G", "16 GB" },
                    { "P1001", 1, "256 GB", "The Iphone 14 Pro Max is the latest flagship model from Apple, featuring advanced camera systems, a stunning Super Retina XDR display, and the powerful A16 Bionic chip.", 34575000m, 25, "Iphone 14 Pro Max", "16 GB" },
                    { "P1002", 1, "256 GB", "The Iphone 13 brings a blend of style and performance with its sleek design, powerful A15 Bionic chip, and impressive camera system, making it a perfect choice for those seeking cutting-edge technology.", 24650m, 45, "Iphone 13", "8 GB" },
                    { "P1003", 1, "256 GB", "The Iphone XS Max features a large Super Retina OLED display, dual-camera system with Smart HDR, and Face ID for secure authentication, offering an exceptional experience for users.", 17000m, 105, "Iphone XS Max", "8 GB" },
                    { "P1004", 1, "64 GB", "The Iphone 8 Plus combines powerful performance with a classic design. It features a dual-camera system, A11 Bionic chip, and Retina HD display, offering a reliable and efficient user experience.", 7080m, 155, "Iphone 8 Plus", "6 GB" },
                    { "P1005", 1, "128 GB", "The Iphone 11 Pro sets new standards with its triple-camera system, Super Retina XDR display, and A13 Bionic chip. It delivers exceptional performance and capabilities, making it ideal for photography enthusiasts and power users.", 11575m, 85, "Iphone 11 Pro", "6 GB" },
                    { "P2001", 2, "512 GB", "The Samsung Galaxy S24 Ultra is the pinnacle of Samsung's smartphone technology, featuring a stunning Dynamic AMOLED 2X display, powerful Exynos 2200 processor, and versatile quad-camera system with 100x Space Zoom.", 29999m, 10, "Samsung Galaxy S24 Ultra", "16 GB" },
                    { "P2002", 2, "128 GB", "The Samsung Galaxy Z Flip5 combines cutting-edge foldable technology with a sleek design. It features a foldable Dynamic AMOLED display, Snapdragon 8 Gen 2 processor, and innovative Flex mode for enhanced user experience.", 20459m, 80, "Samsung Galaxy Z Flip5", "12 GB" },
                    { "P2003", 2, "256 GB", "The Samsung Galaxy S20 Plus offers a balance of performance and features. It includes a vibrant Super AMOLED display, versatile triple-camera setup, and powerful Exynos 990 processor for seamless multitasking.", 12999m, 190, "Samsung Galaxy S20 Plus", "8 GB" },
                    { "P3001", 3, "128 GB", "The Xiaomi POCO X6 Pro delivers exceptional value with its high-performance Snapdragon 870 processor, AMOLED display with 120Hz refresh rate, and quad-camera setup. ", 3540m, 170, "Xiaomi POCO X6 Pro", "8 GB" },
                    { "P3002", 3, "512 GB", "The Xiaomi Redmi 12 Turbo Edition is a budget-friendly smartphone that doesn't compromise on performance. It features a MediaTek Helio G88 processor, large display, and a versatile camera system, making it ideal for everyday use.", 8999m, 40, "Xiaomi Redmi 12 Turbo Edition", "12 GB" },
                    { "P3003", 3, "256 GB", "The Xiaomi Mi 11 Lite combines style with performance, featuring a sleek design, AMOLED display, Snapdragon 732G processor, and triple-camera setup. It's designed for users who prioritize both aesthetics and functionality.", 7900m, 15, "Xiaomi Mi 11 Lite", "8 GB" },
                    { "P4001", 4, "256 GB", "The Oppo Reno11 F offers a seamless blend of design and performance. Featuring a stylish design, AMOLED display, powerful Snapdragon processor, and a versatile camera system, it is perfect for capturing moments and multitasking.", 8490m, 29, "Oppo Reno11 F", "8 GB" },
                    { "P4002", 4, "512 GB", "The Oppo Find X5 Pro is a flagship device designed for premium performance. It comes with a cutting-edge AMOLED display, advanced Snapdragon chipset, and a sophisticated camera system, making it ideal for photography enthusiasts.", 16490m, 75, "Oppo Find X5 Pro", "8 GB" },
                    { "P4003", 4, "1 TB", "The Oppo Find N3 stands out with its innovative design and top-tier features. It boasts a foldable AMOLED display, high-end Snapdragon processor, and a versatile camera array.", 41990m, 5, "Oppo Find N3", "16 GB" },
                    { "P5001", 5, "512 GB", "The Sony Xperia 1 IV is designed for creative professionals, featuring a 4K HDR OLED display, triple-camera system with ZEISS optics, and a powerful Snapdragon 8 Gen 1 processor. Ideal for photography and video enthusiasts.", 29990m, 50, "Sony Xperia 1 IV", "8 GB" },
                    { "P5002", 5, "256 GB", "The Sony Xperia 5 IV offers a compact yet powerful experience with its 6.1-inch OLED display, advanced camera system, and Snapdragon 8 Gen 1 processor. Perfect for users seeking a high-performance smartphone in a smaller form factor.", 24990m, 70, "Sony Xperia 5 IV", "8 GB" },
                    { "P5003", 5, "256 GB", "The Sony Xperia 10 IV combines style and functionality, featuring a 6-inch OLED display, triple-camera setup, and Snapdragon 690 processor. It offers excellent performance and battery life, making it suitable for everyday use.", 14990m, 90, "Sony Xperia 10 IV", "8 GB" },
                    { "P6001", 6, "512 GB", "The Realme GT 2 Pro is a high-performance smartphone featuring a Snapdragon 8 Gen 1 processor, 6.7-inch AMOLED display with a 120Hz refresh rate, and a triple-camera system. It's designed for users seeking top-tier specs and smooth performance.", 18999m, 65, "Realme GT 2 Pro", "16 GB" },
                    { "P6002", 6, "512 GB", "The Realme 9 Pro+ combines advanced features and affordability, offering a 6.4-inch Super AMOLED display, MediaTek Dimensity 920 processor, and a versatile triple-camera setup. It's perfect for those looking for a balance of performance and value.", 14999m, 80, "Realme 9 Pro+", "16 GB" },
                    { "P6003", 6, "128 GB", "The Realme C35 is an entry-level smartphone that doesn't compromise on essential features. It has a 6.6-inch IPS LCD display, Unisoc T616 processor, and a triple-camera system, providing reliable performance for everyday tasks.", 7999m, 120, "Realme C35", "8 GB" },
                    { "P7001", 7, "256 GB", "The VSmart Aris Pro features an innovative under-display camera, a 6.39-inch AMOLED display, Snapdragon 730 processor, and a quad-camera system. It's designed for users seeking cutting-edge technology and sleek design.", 13999m, 50, "VSmart Aris Pro", "8 GB" },
                    { "P7002", 7, "128 GB", "The VSmart Joy 4 is an affordable yet feature-packed smartphone with a 6.53-inch Full HD+ display, Snapdragon 665 processor, and a quad-camera setup. It's ideal for users looking for great value and performance.", 4999m, 75, "VSmart Joy 4", "6 GB" },
                    { "P7003", 7, "128 GB", "The VSmart Active 3 combines modern design and functionality, featuring a 6.39-inch AMOLED display, MediaTek Helio P60 processor, and a triple-camera system. It offers excellent performance and aesthetics for everyday use.", 7999m, 90, "VSmart Active 3", "8 GB" },
                    { "P8001", 8, "256 GB", "The Vivo X80 Pro offers a premium smartphone experience with its 6.78-inch AMOLED display, Snapdragon 8 Gen 1 processor, and advanced quad-camera system co-engineered with ZEISS.", 24999m, 40, "Vivo X80 Pro", "8 GB" },
                    { "P8002", 8, "512 GB", "The Vivo V23 5G combines style and innovation, featuring a 6.44-inch AMOLED display, MediaTek Dimensity 920 processor, and a dual front camera system with a 50MP main sensor.", 19999m, 60, "Vivo V23 5G", "8 GB" },
                    { "P8003", 8, "256 GB", "The Vivo Y75 is a versatile and affordable smartphone, boasting a 6.58-inch Full HD+ display, MediaTek Helio G96 processor, and a triple-camera setup.", 12999m, 100, "Vivo Y75", "8 GB" },
                    { "P9001", 9, "1 TB", "The OnePlus 10 Pro offers a flagship experience with its 6.7-inch Fluid AMOLED display, Snapdragon 8 Gen 1 processor, and Hasselblad-tuned triple-camera system.", 31999m, 50, "OnePlus 10 Pro", "16 GB" },
                    { "P9002", 9, "512 GB", "The OnePlus Nord 2T combines performance and affordability, featuring a 6.43-inch AMOLED display, MediaTek Dimensity 1300 processor, and a versatile triple-camera setup.", 19999m, 70, "OnePlus Nord 2T", "8 GB" },
                    { "P9003", 9, "256 GB", "The OnePlus 9R offers a premium experience with its 6.55-inch Fluid AMOLED display, Snapdragon 870 processor, and quad-camera system. It provides a smooth and responsive performance.", 24999m, 90, "OnePlus 9R", "16 GB" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AccountId", "OrderDate", "OrderStatus" },
                values: new object[,]
                {
                    { "O0001", 4, new DateTime(2024, 7, 18, 4, 10, 8, 50, DateTimeKind.Local).AddTicks(197), "Confirmed" },
                    { "O0002", 10, new DateTime(2024, 7, 18, 4, 10, 8, 50, DateTimeKind.Local).AddTicks(218), "Pending" },
                    { "O0003", 4, new DateTime(2024, 7, 18, 4, 10, 8, 50, DateTimeKind.Local).AddTicks(220), "Cancelled" },
                    { "O0004", 9, new DateTime(2024, 7, 18, 4, 10, 8, 50, DateTimeKind.Local).AddTicks(222), "Confirmed" },
                    { "O0005", 8, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { "O0006", 4, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { "O0007", 5, new DateTime(2024, 7, 18, 4, 10, 8, 50, DateTimeKind.Local).AddTicks(226), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductPhoneId", "Quantity", "TotalPrice" },
                values: new object[,]
                {
                    { "O0001", "P1001", 2, 69998m },
                    { "O0001", "P2002", 1, 20459m },
                    { "O0002", "P3001", 3, 44997m },
                    { "O0003", "P4003", 1, 41990m },
                    { "O0004", "P5003", 4, 79996m },
                    { "O0005", "P1003", 3, 51000m },
                    { "O0006", "P2001", 2, 59998m },
                    { "O0007", "P3002", 1, 5999m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductPhoneId",
                table: "OrderDetails",
                column: "ProductPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
