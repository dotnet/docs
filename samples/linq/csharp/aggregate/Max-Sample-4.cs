using System;
using System.Collections.Generic;
using System.Linq;

namespace Aggregate
{
    public static class MaxSample4
    {

        //This sample uses Max and query syntax to get the products with the most expensive price in each category.
        //
        //Output:
        //
        // The most expensive product in the Beverages category is Cote de Blaye.
        // The most expensive product in the Condiments category is Vegie-spread.
        // The most expensive product in the Produce category is Manjimup Dried Apples.
        // The most expensive product in the Meat/Poultry category is Thuringer Rostbratwurst.
        // The most expensive product in the Seafood category is Carnarvon Tigers.
        // The most expensive product in the Dairy Products category is Raclette Courdavault.
        // The most expensive product in the Confections category is Sir Rodney's Marmalade.
        // The most expensive product in the Grains/Cereals category is Gnocchi di nonna Alice.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                from prod in products
                group prod by prod.Category
                into prodGroup
                let maxPrice = prodGroup.Max(p => p.UnitPrice)
                select
                    new
                    {
                        CategoryName = prodGroup.Key,
                        MostExpensiveProducts = prodGroup.Where(p => p.UnitPrice == maxPrice)
                    };

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The most expensive product in the {category.CategoryName} category is {category.MostExpensiveProducts.First().ProductName}.");
            }
        }

        //This sample uses Max and method syntax to get the products with the most expensive price in each category.
        //
        //Output:
        //
        // The most expensive product in the Beverages category is Cote de Blaye.
        // The most expensive product in the Condiments category is Vegie-spread.
        // The most expensive product in the Produce category is Manjimup Dried Apples.
        // The most expensive product in the Meat/Poultry category is Thuringer Rostbratwurst.
        // The most expensive product in the Seafood category is Carnarvon Tigers.
        // The most expensive product in the Dairy Products category is Raclette Courdavault.
        // The most expensive product in the Confections category is Sir Rodney's Marmalade.
        // The most expensive product in the Grains/Cereals category is Gnocchi di nonna Alice.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                products.GroupBy(prod => prod.Category)
                    .Select(prodGroup => new {prodGroup, maxPrice = prodGroup.Max(p => p.UnitPrice)})
                    .Select(@t => new
                    {
                        CategoryName = @t.prodGroup.Key,
                        MostExpensiveProducts = @t.prodGroup.Where(p => p.UnitPrice == @t.maxPrice)
                    });

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The most expensive product in the {category.CategoryName} category is {category.MostExpensiveProducts.First().ProductName}.");
            }
        }
    }
}