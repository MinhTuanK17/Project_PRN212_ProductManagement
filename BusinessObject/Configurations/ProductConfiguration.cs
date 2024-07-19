using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BusinessObject.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductPhoneId).HasMaxLength(7);
            builder.Property(p => p.ProductPhoneName).HasMaxLength(100);
            builder.Property(p => p.PhoneDescription).HasMaxLength(1000);
            builder.Property(p => p.MemoryPhone).HasMaxLength(12);
            builder.Property(p => p.RamPhone).HasMaxLength(12);
            builder.Property(p => p.PhonePrice).HasColumnType("money");

            builder.HasData(
                new Product
                {
                    ProductPhoneId = "P1001",
                    ProductPhoneName = "Iphone 14 Pro Max",
                    PhonePrice = 34575m,
                    PhoneQuantity = 25,
                    RamPhone = "16 GB",
                    MemoryPhone = "256 GB",
                    PhoneDescription = "The Iphone 14 Pro Max is the latest flagship model from Apple, featuring advanced camera systems, a stunning Super Retina XDR display, and the powerful A16 Bionic chip.",
                    CategoryId = 1
                },
                 new Product
                 {
                     ProductPhoneId = "P1002",
                     ProductPhoneName = "Iphone 13",
                     PhonePrice = 24650m,
                     PhoneQuantity = 45,
                     RamPhone = "8 GB",
                     MemoryPhone = "256 GB",
                     PhoneDescription = "The Iphone 13 brings a blend of style and performance with its sleek design, powerful A15 Bionic chip, and impressive camera system, making it a perfect choice for those seeking cutting-edge technology.",
                     CategoryId = 1
                 },
                  new Product
                  {
                      ProductPhoneId = "P1003",
                      ProductPhoneName = "Iphone XS Max",
                      PhonePrice = 17000m,
                      PhoneQuantity = 105,
                      RamPhone = "8 GB",
                      MemoryPhone = "256 GB",
                      PhoneDescription = "The Iphone XS Max features a large Super Retina OLED display, dual-camera system with Smart HDR, and Face ID for secure authentication, offering an exceptional experience for users.",
                      CategoryId = 1
                  },
                   new Product
                   {
                       ProductPhoneId = "P1004",
                       ProductPhoneName = "Iphone 8 Plus",
                       PhonePrice = 7080m,
                       PhoneQuantity = 155,
                       RamPhone = "6 GB",
                       MemoryPhone = "64 GB",
                       PhoneDescription = "The Iphone 8 Plus combines powerful performance with a classic design. It features a dual-camera system, A11 Bionic chip, and Retina HD display, offering a reliable and efficient user experience.",
                       CategoryId = 1
                   },
                   new Product
                   {
                       ProductPhoneId = "P1005",
                       ProductPhoneName = "Iphone 11 Pro",
                       PhonePrice = 11575m,
                       PhoneQuantity = 85,
                       RamPhone = "6 GB",
                       MemoryPhone = "128 GB",
                       PhoneDescription = "The Iphone 11 Pro sets new standards with its triple-camera system, Super Retina XDR display, and A13 Bionic chip. It delivers exceptional performance and capabilities, making it ideal for photography enthusiasts and power users.",
                       CategoryId = 1
                   },
                    new Product
                    {
                        ProductPhoneId = "P2001",
                        ProductPhoneName = "Samsung Galaxy S24 Ultra",
                        PhonePrice = 29999m,
                        PhoneQuantity = 10,
                        RamPhone = "16 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Samsung Galaxy S24 Ultra is the pinnacle of Samsung's smartphone technology, featuring a stunning Dynamic AMOLED 2X display, powerful Exynos 2200 processor, and versatile quad-camera system with 100x Space Zoom.",
                        CategoryId = 2
                    },
                    new Product
                    {
                        ProductPhoneId = "P2002",
                        ProductPhoneName = "Samsung Galaxy Z Flip5",
                        PhonePrice = 20459m,
                        PhoneQuantity = 80,
                        RamPhone = "12 GB",
                        MemoryPhone = "128 GB",
                        PhoneDescription = "The Samsung Galaxy Z Flip5 combines cutting-edge foldable technology with a sleek design. It features a foldable Dynamic AMOLED display, Snapdragon 8 Gen 2 processor, and innovative Flex mode for enhanced user experience.",
                        CategoryId = 2
                    },
                    new Product
                    {
                        ProductPhoneId = "P2003",
                        ProductPhoneName = "Samsung Galaxy S20 Plus",
                        PhonePrice = 12999m,
                        PhoneQuantity = 190,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Samsung Galaxy S20 Plus offers a balance of performance and features. It includes a vibrant Super AMOLED display, versatile triple-camera setup, and powerful Exynos 990 processor for seamless multitasking.",
                        CategoryId = 2
                    },
                    new Product
                    {
                        ProductPhoneId = "P3001",
                        ProductPhoneName = "Xiaomi POCO X6 Pro",
                        PhonePrice = 3540m,
                        PhoneQuantity = 170,
                        RamPhone = "8 GB",
                        MemoryPhone = "128 GB",
                        PhoneDescription = "The Xiaomi POCO X6 Pro delivers exceptional value with its high-performance Snapdragon 870 processor, AMOLED display with 120Hz refresh rate, and quad-camera setup. ",
                        CategoryId = 3
                    },
                    new Product
                    {
                        ProductPhoneId = "P3002",
                        ProductPhoneName = "Xiaomi Redmi 12 Turbo Edition",
                        PhonePrice = 8999m,
                        PhoneQuantity = 40,
                        RamPhone = "12 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Xiaomi Redmi 12 Turbo Edition is a budget-friendly smartphone that doesn't compromise on performance. It features a MediaTek Helio G88 processor, large display, and a versatile camera system, making it ideal for everyday use.",
                        CategoryId = 3
                    },
                    new Product
                    {
                        ProductPhoneId = "P3003",
                        ProductPhoneName = "Xiaomi Mi 11 Lite",
                        PhonePrice = 7900m,
                        PhoneQuantity = 15,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Xiaomi Mi 11 Lite combines style with performance, featuring a sleek design, AMOLED display, Snapdragon 732G processor, and triple-camera setup. It's designed for users who prioritize both aesthetics and functionality.",
                        CategoryId = 3
                    },
                    new Product
                    {
                        ProductPhoneId = "P4001",
                        ProductPhoneName = "Oppo Reno11 F",
                        PhonePrice = 8490m,
                        PhoneQuantity = 29,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Oppo Reno11 F offers a seamless blend of design and performance. Featuring a stylish design, AMOLED display, powerful Snapdragon processor, and a versatile camera system, it is perfect for capturing moments and multitasking.",
                        CategoryId = 4
                    },
                    new Product
                    {
                        ProductPhoneId = "P4002",
                        ProductPhoneName = "Oppo Find X5 Pro",
                        PhonePrice = 16490m,
                        PhoneQuantity = 75,
                        RamPhone = "8 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Oppo Find X5 Pro is a flagship device designed for premium performance. It comes with a cutting-edge AMOLED display, advanced Snapdragon chipset, and a sophisticated camera system, making it ideal for photography enthusiasts.",
                        CategoryId = 4
                    },
                    new Product
                    {
                        ProductPhoneId = "P4003",
                        ProductPhoneName = "Oppo Find N3",
                        PhonePrice = 41990m,
                        PhoneQuantity = 5,
                        RamPhone = "16 GB",
                        MemoryPhone = "1 TB",
                        PhoneDescription = "The Oppo Find N3 stands out with its innovative design and top-tier features. It boasts a foldable AMOLED display, high-end Snapdragon processor, and a versatile camera array.",
                        CategoryId = 4
                    },
                    new Product
                    {
                        ProductPhoneId = "P5001",
                        ProductPhoneName = "Sony Xperia 1 IV",
                        PhonePrice = 29990m,
                        PhoneQuantity = 50,
                        RamPhone = "8 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Sony Xperia 1 IV is designed for creative professionals, featuring a 4K HDR OLED display, triple-camera system with ZEISS optics, and a powerful Snapdragon 8 Gen 1 processor. Ideal for photography and video enthusiasts.",
                        CategoryId = 5
                    },
                    new Product
                    {
                        ProductPhoneId = "P5002",
                        ProductPhoneName = "Sony Xperia 5 IV",
                        PhonePrice = 24990m,
                        PhoneQuantity = 70,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Sony Xperia 5 IV offers a compact yet powerful experience with its 6.1-inch OLED display, advanced camera system, and Snapdragon 8 Gen 1 processor. Perfect for users seeking a high-performance smartphone in a smaller form factor.",
                        CategoryId = 5
                    },
                    new Product
                    {
                        ProductPhoneId = "P5003",
                        ProductPhoneName = "Sony Xperia 10 IV",
                        PhonePrice = 14990m,
                        PhoneQuantity = 90,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Sony Xperia 10 IV combines style and functionality, featuring a 6-inch OLED display, triple-camera setup, and Snapdragon 690 processor. It offers excellent performance and battery life, making it suitable for everyday use.",
                        CategoryId = 5
                    },
                    new Product
                    {
                        ProductPhoneId = "P6001",
                        ProductPhoneName = "Realme GT 2 Pro",
                        PhonePrice = 18999m,
                        PhoneQuantity = 65,
                        RamPhone = "16 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Realme GT 2 Pro is a high-performance smartphone featuring a Snapdragon 8 Gen 1 processor, 6.7-inch AMOLED display with a 120Hz refresh rate, and a triple-camera system. It's designed for users seeking top-tier specs and smooth performance.",
                        CategoryId = 6
                    },
                    new Product
                    {
                        ProductPhoneId = "P6002",
                        ProductPhoneName = "Realme 9 Pro+",
                        PhonePrice = 14999m,
                        PhoneQuantity = 80,
                        RamPhone = "16 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Realme 9 Pro+ combines advanced features and affordability, offering a 6.4-inch Super AMOLED display, MediaTek Dimensity 920 processor, and a versatile triple-camera setup. It's perfect for those looking for a balance of performance and value.",
                        CategoryId = 6
                    },
                    new Product
                    {
                        ProductPhoneId = "P6003",
                        ProductPhoneName = "Realme C35",
                        PhonePrice = 7999m,
                        PhoneQuantity = 120,
                        RamPhone = "8 GB",
                        MemoryPhone = "128 GB",
                        PhoneDescription = "The Realme C35 is an entry-level smartphone that doesn't compromise on essential features. It has a 6.6-inch IPS LCD display, Unisoc T616 processor, and a triple-camera system, providing reliable performance for everyday tasks.",
                        CategoryId = 6
                    },
                    new Product
                    {
                        ProductPhoneId = "P7001",
                        ProductPhoneName = "VSmart Aris Pro",
                        PhonePrice = 13999m,
                        PhoneQuantity = 50,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The VSmart Aris Pro features an innovative under-display camera, a 6.39-inch AMOLED display, Snapdragon 730 processor, and a quad-camera system. It's designed for users seeking cutting-edge technology and sleek design.",
                        CategoryId = 7
                    },
                    new Product
                    {
                        ProductPhoneId = "P7002",
                        ProductPhoneName = "VSmart Joy 4",
                        PhonePrice = 4999m,
                        PhoneQuantity = 75,
                        RamPhone = "6 GB",
                        MemoryPhone = "128 GB",
                        PhoneDescription = "The VSmart Joy 4 is an affordable yet feature-packed smartphone with a 6.53-inch Full HD+ display, Snapdragon 665 processor, and a quad-camera setup. It's ideal for users looking for great value and performance.",
                        CategoryId = 7
                    },
                    new Product
                    {
                        ProductPhoneId = "P7003",
                        ProductPhoneName = "VSmart Active 3",
                        PhonePrice = 7999m,
                        PhoneQuantity = 90,
                        RamPhone = "8 GB",
                        MemoryPhone = "128 GB",
                        PhoneDescription = "The VSmart Active 3 combines modern design and functionality, featuring a 6.39-inch AMOLED display, MediaTek Helio P60 processor, and a triple-camera system. It offers excellent performance and aesthetics for everyday use.",
                        CategoryId = 7
                    },
                    new Product
                    {
                        ProductPhoneId = "P8001",
                        ProductPhoneName = "Vivo X80 Pro",
                        PhonePrice = 24999m,
                        PhoneQuantity = 40,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Vivo X80 Pro offers a premium smartphone experience with its 6.78-inch AMOLED display, Snapdragon 8 Gen 1 processor, and advanced quad-camera system co-engineered with ZEISS.",
                        CategoryId = 8
                    },
                    new Product
                    {
                        ProductPhoneId = "P8002",
                        ProductPhoneName = "Vivo V23 5G",
                        PhonePrice = 19999m,
                        PhoneQuantity = 60,
                        RamPhone = "8 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Vivo V23 5G combines style and innovation, featuring a 6.44-inch AMOLED display, MediaTek Dimensity 920 processor, and a dual front camera system with a 50MP main sensor.",
                        CategoryId = 8
                    },
                    new Product
                    {
                        ProductPhoneId = "P8003",
                        ProductPhoneName = "Vivo Y75",
                        PhonePrice = 12999m,
                        PhoneQuantity = 100,
                        RamPhone = "8 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Vivo Y75 is a versatile and affordable smartphone, boasting a 6.58-inch Full HD+ display, MediaTek Helio G96 processor, and a triple-camera setup.",
                        CategoryId = 8
                    },
                    new Product
                    {
                        ProductPhoneId = "P9001",
                        ProductPhoneName = "OnePlus 10 Pro",
                        PhonePrice = 31999m,
                        PhoneQuantity = 50,
                        RamPhone = "16 GB",
                        MemoryPhone = "1 TB",
                        PhoneDescription = "The OnePlus 10 Pro offers a flagship experience with its 6.7-inch Fluid AMOLED display, Snapdragon 8 Gen 1 processor, and Hasselblad-tuned triple-camera system.",
                        CategoryId = 9
                    },
                    new Product
                    {
                        ProductPhoneId = "P9002",
                        ProductPhoneName = "OnePlus Nord 2T",
                        PhonePrice = 19999m,
                        PhoneQuantity = 70,
                        RamPhone = "8 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The OnePlus Nord 2T combines performance and affordability, featuring a 6.43-inch AMOLED display, MediaTek Dimensity 1300 processor, and a versatile triple-camera setup.",
                        CategoryId = 9
                    },
                    new Product
                    {
                        ProductPhoneId = "P9003",
                        ProductPhoneName = "OnePlus 9R",
                        PhonePrice = 24999m,
                        PhoneQuantity = 90,
                        RamPhone = "16 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The OnePlus 9R offers a premium experience with its 6.55-inch Fluid AMOLED display, Snapdragon 870 processor, and quad-camera system. It provides a smooth and responsive performance.",
                        CategoryId = 9
                    },
                    new Product
                    {
                        ProductPhoneId = "P10001",
                        ProductPhoneName = "Nokia X20",
                        PhonePrice = 15999m,
                        PhoneQuantity = 60,
                        RamPhone = "12 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Nokia X20 combines durability and performance with its 6.67-inch Full HD+ display, Snapdragon 480 5G processor, and quad-camera setup.",
                        CategoryId = 10
                    },
                    new Product
                    {
                        ProductPhoneId = "P10002",
                        ProductPhoneName = "Nokia G50",
                        PhonePrice = 12999m,
                        PhoneQuantity = 80,
                        RamPhone = "12 GB",
                        MemoryPhone = "256 GB",
                        PhoneDescription = "The Nokia G50 is an affordable 5G smartphone featuring a 6.82-inch HD+ display, Snapdragon 480 5G processor, and a triple-camera system.",
                        CategoryId = 10
                    },
                    new Product
                    {
                        ProductPhoneId = "P10003",
                        ProductPhoneName = "Nokia 8.3 5G",
                        PhonePrice = 22999m,
                        PhoneQuantity = 50,
                        RamPhone = "16 GB",
                        MemoryPhone = "512 GB",
                        PhoneDescription = "The Nokia 8.3 5G offers a premium experience with its 6.81-inch PureDisplay, Snapdragon 765G processor, and quad-camera system with ZEISS optics. It is designed for users who want cutting-edge technology and superior camera capabilities.",
                        CategoryId = 10
                    }
               ) ;
        }
    }
}
