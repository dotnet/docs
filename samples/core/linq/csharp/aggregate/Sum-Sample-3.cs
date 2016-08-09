using System;
using System.Collections.Generic;
using System.Linq;

namespace Aggregate
{
    public static class SumSample3
    {
        //This sample uses Sum amd query syntax to get the total units in stock for each product category.
        // 
        // Output: 
        // Category Beverages has 559 unit(s) in stock.
        // Category Condiments has 507 unit(s) in stock.
        // Category Produce has 100 unit(s) in stock.
        // Category Meat/Poultry has 165 unit(s) in stock.
        // Category Seafood has 701 unit(s) in stock.
        // Category Dairy Products has 393 unit(s) in stock.
        // Category Confections has 386 unit(s) in stock.
        // Category Grains/Cereals has 308 unit(s) in stock.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                from prod in products
                group prod by prod.Category
                into prodGroup
                select new {CategoryName = prodGroup.Key, TotalUnitsInStock = prodGroup.Sum(p => p.UnitsInStock)};
            foreach (var category in categories)
            {
                Console.WriteLine($"Category {category.CategoryName} has {category.TotalUnitsInStock} unit(s) in stock.");
            }
        }

        //This sample uses Sum and method syntax to get the total units in stock for each product category.
        // 
        // Output: 
        // Category Beverages has 559 unit(s) in stock.
        // Category Condiments has 507 unit(s) in stock.
        // Category Produce has 100 unit(s) in stock.
        // Category Meat/Poultry has 165 unit(s) in stock.
        // Category Seafood has 701 unit(s) in stock.
        // Category Dairy Products has 393 unit(s) in stock.
        // Category Confections has 386 unit(s) in stock.
        // Category Grains/Cereals has 308 unit(s) in stock.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                products.GroupBy(prod => prod.Category)
                    .Select(
                        prodGroup =>
                            new {CategoryName = prodGroup.Key, TotalUnitsInStock = prodGroup.Sum(p => p.UnitsInStock)});
            foreach (var category in categories)
            {
                Console.WriteLine($"Category {category.CategoryName} has {category.TotalUnitsInStock} unit(s) in stock.");
            }
        }
    }
}