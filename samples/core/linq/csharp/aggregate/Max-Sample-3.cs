using System;
using System.Collections.Generic;
using System.Linq;

namespace Aggregate
{
    public static class MaxSample3
    {
        //This sample uses Max and query syntax to get the most expensive price among each category's products.
        //
        //Output:
        // The most expensive price for an item in the Beverages category is $263.50.
        // The most expensive price for an item in the Condiments category is $43.90.
        // The most expensive price for an item in the Produce category is $53.00.
        // The most expensive price for an item in the Meat/Poultry category is $123.79.
        // The most expensive price for an item in the Seafood category is $62.50.
        // The most expensive price for an item in the Dairy Products category is $55.00.
        // The most expensive price for an item in the Confections category is $81.00.
        // The most expensive price for an item in the Grains/Cereals category is $38.00.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                from prod in products
                group prod by prod.Category
                into prodGroup
                select new {CategoryName = prodGroup.Key, MostExpensivePrice = prodGroup.Max(p => p.UnitPrice)};

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The most expensive price for an item in the {category.CategoryName} category is {category.MostExpensivePrice:C}.");
            }
        }

        //This sample uses Max and method syntax to get the most expensive price among each category's products.
        //
        //Output:
        // The most expensive price for an item in the Beverages category is $263.50.
        // The most expensive price for an item in the Condiments category is $43.90.
        // The most expensive price for an item in the Produce category is $53.00.
        // The most expensive price for an item in the Meat/Poultry category is $123.79.
        // The most expensive price for an item in the Seafood category is $62.50.
        // The most expensive price for an item in the Dairy Products category is $55.00.
        // The most expensive price for an item in the Confections category is $81.00.
        // The most expensive price for an item in the Grains/Cereals category is $38.00.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                products.GroupBy(prod => prod.Category)
                    .Select(
                        prodGroup =>
                            new {CategoryName = prodGroup.Key, MostExpensivePrice = prodGroup.Max(p => p.UnitPrice)});

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The most expensive price for an item in the {category.CategoryName} category is {category.MostExpensivePrice:C}.");
            }
        }
    }
}