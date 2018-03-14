using System;
using System.Collections.Generic;
using System.Linq;

namespace Aggregate
{
    public static class MinSample3
    {
        //This sample uses Min and query syntax to get the cheapest price among each category's products.
        // 
        //Output: 
        // The cheapest price for an item in the Beverages category is $4.50.
        // The cheapest price for an item in the Condiments category is $10.00.
        // The cheapest price for an item in the Produce category is $10.00.
        // The cheapest price for an item in the Meat/Poultry category is $7.45.
        // The cheapest price for an item in the Seafood category is $6.00.
        // The cheapest price for an item in the Dairy Products category is $2.50.
        // The cheapest price for an item in the Confections category is $9.20.
        // The cheapest price for an item in the Grains/Cereals category is $7.00.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                from p in products
                group p by p.Category
                into g
                select new {CategoryName = g.Key, CheapestPrice = g.Min(p => p.UnitPrice)};
            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The cheapest price for an item in the {category.CategoryName} category is {category.CheapestPrice:C}.");
            }
        }

        //This sample uses Min and method syntax to get the cheapest price among each category's products.
        // 
        //Output: 
        // The cheapest price for an item in the Beverages category is $4.50.
        // The cheapest price for an item in the Condiments category is $10.00.
        // The cheapest price for an item in the Produce category is $10.00.
        // The cheapest price for an item in the Meat/Poultry category is $7.45.
        // The cheapest price for an item in the Seafood category is $6.00.
        // The cheapest price for an item in the Dairy Products category is $2.50.
        // The cheapest price for an item in the Confections category is $9.20.
        // The cheapest price for an item in the Grains/Cereals category is $7.00.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                products.GroupBy(p => p.Category)
                    .Select(g => new {CategoryName = g.Key, CheapestPrice = g.Min(p => p.UnitPrice)});
            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The cheapest price for an item in the {category.CategoryName} category is {category.CheapestPrice:C}.");
            }
        }
    }
}