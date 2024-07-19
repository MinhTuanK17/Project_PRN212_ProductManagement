using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Iphone" },
                new Category { CategoryId = 2, CategoryName = "Samsung" },
                new Category { CategoryId = 3, CategoryName = "Xiaomi" },
                new Category { CategoryId = 4, CategoryName = "Oppo" },
                new Category { CategoryId = 5, CategoryName = "Sony" },
                new Category { CategoryId = 6, CategoryName = "Realme" },
                new Category { CategoryId = 7, CategoryName = "VSmart" },
                new Category { CategoryId = 8, CategoryName = "Vivo" },
                new Category { CategoryId = 9, CategoryName = "One Plus" },
                new Category { CategoryId = 10, CategoryName = "Nokia" }
            );
        }
    }
}
