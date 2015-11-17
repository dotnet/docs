using System;
using System.Collections.Generic;
using System.Linq;

namespace Aggregate
{
    public static class CountSample4
    {
        //This sample uses Count and query syntax to return a list of product counts per category.
        // 
        //Output: 
        // There are 12 products in the Beverages category.
        // There are 12 products in the Condiments category.
        // There are 5 products in the Produce category.
        // There are 6 products in the Meat/Poultry category.
        // There are 12 products in the Seafood category.
        // There are 10 products in the Dairy Products category.
        // There are 13 products in the Confections category.
        // There are 7 products in the Grains/Cereals category.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var categoryCounts =
                from prod in products
                group prod by prod.Category
                into prodGroup
                select new {CategoryName = prodGroup.Key, ProductCount = prodGroup.Count()};

            foreach (var item in categoryCounts)
            {
                Console.WriteLine($"There are {item.ProductCount} products in the {item.CategoryName} category.");
            }
        }

        //This sample uses Count and method syntax to return a list of product counts per category.
        // 
        //Output: 
        // There are 12 products in the Beverages category.
        // There are 12 products in the Condiments category.
        // There are 5 products in the Produce category.
        // There are 6 products in the Meat/Poultry category.
        // There are 12 products in the Seafood category.
        // There are 10 products in the Dairy Products category.
        // There are 13 products in the Confections category.
        // There are 7 products in the Grains/Cereals category.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var categoryCounts =
                products.GroupBy(prod => prod.Category)
                    .Select(prodGroup => new {CategoryName = prodGroup.Key, ProductCount = prodGroup.Count()});

            foreach (var item in categoryCounts)
            {
                Console.WriteLine($"There are {item.ProductCount} products in the {item.CategoryName} category.");
            }
        }
    }
}