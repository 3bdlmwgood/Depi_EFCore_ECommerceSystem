
using ConsoleApp1.Data;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Create

            using var dbContext = new AppDbContext();

            var category = new Category
            {
                Name = "Electronics",
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "Laptop",
                        Price = 25000
                    },
                    new Product
                    {
                        Name = "Mouse",
                        Price = 500
                    }
                }
            };

            dbContext.Categories.Add(category);

            dbContext.SaveChanges();

            #endregion

            #region Read

            var categories = dbContext.Categories
                .Include(c => c.Products)
                .ToList();

            foreach (var cat in categories)
            {
                Console.WriteLine($"Category: {cat.Name}");

                foreach (var product in cat.Products)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }
            }

            #endregion
        }
    }
}
