using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aggregate
{
    public static class MinSample4
    {
        //This sample uses Min and query syntax to get the products with the lowest price in each category.
        // 
        //Output:
        // The cheapest product in the Beverages category is Guarana Fantastica.
        // The cheapest product in the Condiments category is Aniseed Syrup.
        // The cheapest product in the Produce category is Longlife Tofu.
        // The cheapest product in the Meat/Poultry category is Tourtiere.
        // The cheapest product in the Seafood category is Konbu.
        // The cheapest product in the Dairy Products category is Geitost.
        // The cheapest product in the Confections category is Teatime Chocolate Biscuits.
        // The cheapest product in the Grains/Cereals category is Filo Mix.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                let minPrice = prodGroup.Min(p => p.UnitPrice)
                select new { CategoryName = prodGroup.Key, CheapestProducts = prodGroup.Where(p => p.UnitPrice == minPrice) };

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The cheapest product in the {category.CategoryName} category is {category.CheapestProducts.First().ProductName}.");
            }
        }

        //This sample uses Min and method syntax to get the products with the lowest price in each category.
        // 
        //Output:
        // The cheapest product in the Beverages category is Guarana Fantastica.
        // The cheapest product in the Condiments category is Aniseed Syrup.
        // The cheapest product in the Produce category is Longlife Tofu.
        // The cheapest product in the Meat/Poultry category is Tourtiere.
        // The cheapest product in the Seafood category is Konbu.
        // The cheapest product in the Dairy Products category is Geitost.
        // The cheapest product in the Confections category is Teatime Chocolate Biscuits.
        // The cheapest product in the Grains/Cereals category is Filo Mix.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                products.GroupBy(prod => prod.Category)
                    .Select(prodGroup => new {prodGroup, minPrice = prodGroup.Min(p => p.UnitPrice)})
                    .Select(
                        @t =>
                            new
                            {
                                CategoryName = @t.prodGroup.Key,
                                CheapestProducts = @t.prodGroup.Where(p => p.UnitPrice == @t.minPrice)
                            });

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"The cheapest product in the {category.CategoryName} category is {category.CheapestProducts.First().ProductName}.");
            }
        }
    }
}