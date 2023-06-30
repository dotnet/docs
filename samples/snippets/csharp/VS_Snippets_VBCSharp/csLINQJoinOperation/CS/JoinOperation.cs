using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
    class JoinOperation
    {
        static void Main(string[] args)
        {
            Join.Example();
        }

        static class Join
        {
            // <SnippetJoin>
            class Product
            {
                public string? Name { get; set; }
                public int CategoryId { get; set; }
            }

            class Category
            {
                public int Id { get; set; }
                public string? CategoryName { get; set; }
            }

            public static void Example()
            {
                List<Product> products = new List<Product>
                {
                    new Product { Name = "Cola", CategoryId = 0 },
                    new Product { Name = "Tea", CategoryId = 0 },
                    new Product { Name = "Apple", CategoryId = 1 },
                    new Product { Name = "Kiwi", CategoryId = 1 },
                    new Product { Name = "Carrot", CategoryId = 2 },
                };

                List<Category> categories = new List<Category>
                {
                    new Category { Id = 0, CategoryName = "Beverage" },
                    new Category { Id = 1, CategoryName = "Fruit" },
                    new Category { Id = 2, CategoryName = "Vegetable" }
                };

                // Join products and categories based on CategoryId
                var query = from product in products
                            join category in categories on product.CategoryId equals category.Id
                            select new { product.Name, category.CategoryName };

                foreach (var item in query)
                {
                    Console.WriteLine($"{item.Name} - {item.CategoryName}");
                }

                // This code produces the following output:
                //
                // Cola - Beverage
                // Tea - Beverage
                // Apple - Fruit
                // Kiwi - Fruit
                // Carrot - Vegetable
            }
            // </SnippetJoin>
        }

        static class GroupJoin
        {
            // <SnippetGroupJoin>
            class Product
            {
                public string? Name { get; set; }
                public int CategoryId { get; set; }
            }

            class Category
            {
                public int Id { get; set; }
                public string? CategoryName { get; set; }
            }

            public static void Example()
            {
                List<Product> products = new List<Product>
                {
                    new Product { Name = "Cola", CategoryId = 0 },
                    new Product { Name = "Tea", CategoryId = 0 },
                    new Product { Name = "Apple", CategoryId = 1 },
                    new Product { Name = "Kiwi", CategoryId = 1 },
                    new Product { Name = "Carrot", CategoryId = 2 },
                };

                List<Category> categories = new List<Category>
                {
                    new Category { Id = 0, CategoryName = "Beverage" },
                    new Category { Id = 1, CategoryName = "Fruit" },
                    new Category { Id = 2, CategoryName = "Vegetable" }
                };

                // Join categories and product based on CategoryId and grouping result
                var productGroups = from category in categories
                                    join product in products on category.Id equals product.CategoryId into productGroup
                                    select productGroup;

                foreach (IEnumerable<Product> productGroup in productGroups)
                {
                    Console.WriteLine("Group");
                    foreach (Product product in productGroup)
                    {
                        Console.WriteLine($"{product.Name,8}");
                    }
                }

                // This code produces the following output:
                //
                // Group
                //     Cola
                //      Tea
                // Group
                //    Apple
                //     Kiwi
                // Group
                //   Carrot
            }
            // </SnippetGroupJoin>
        }
    }
}
