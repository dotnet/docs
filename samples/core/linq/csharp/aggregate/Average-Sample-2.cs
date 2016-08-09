using System;
using System.Collections.Generic;
using System.Linq;

namespace Aggregate
{
    public static class AverageSample2
    {
        //This sample uses Average to get the average length of the words in the array.
        //
        //Outputs:
        // The average word length is 6.66666666666667 characters.
        public static void Example()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double averageLength = words.Average(w => w.Length);

            Console.WriteLine("The average word length is {0} characters.", averageLength);
        }
    }

    public static class AverageSample3
    {
        //This sample uses Average and query syntax to get the average price of each category's products.
        //
        //Outputs:
        // The average price for a product in the Beverages category is $37.98.
        // The average price for a product in the Condiments category is $23.06.
        // The average price for a product in the Produce category is $32.37.
        // The average price for a product in the Meat/Poultry category is $54.01.
        // The average price for a product in the Seafood category is $20.68.
        // The average price for a product in the Dairy Products category is $28.73.
        // The average price for a product in the Confections category is $25.16.
        // The average price for a product in the Grains/Cereals category is $20.25.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                select new { CategoryName = prodGroup.Key, AveragePrice = prodGroup.Average(p => p.UnitPrice) };

            foreach (var category in categories)
            {
                Console.WriteLine($"The average price for a product in the {category.CategoryName} category is {category.AveragePrice:C}.");
            }
        }

        //This sample uses Average and method syntax to get the average price of each category's products.
        //
        //Outputs:
        // The average price for a product in the Beverages category is $37.98.
        // The average price for a product in the Condiments category is $23.06.
        // The average price for a product in the Produce category is $32.37.
        // The average price for a product in the Meat/Poultry category is $54.01.
        // The average price for a product in the Seafood category is $20.68.
        // The average price for a product in the Dairy Products category is $28.73.
        // The average price for a product in the Confections category is $25.16.
        // The average price for a product in the Grains/Cereals category is $20.25.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var categories =
                products.GroupBy(prod => prod.Category)
                    .Select(
                        prodGroup => new {CategoryName = prodGroup.Key, AveragePrice = prodGroup.Average(p => p.UnitPrice)});

            foreach (var category in categories)
            {
                Console.WriteLine($"The average price for a product in the {category.CategoryName} category is {category.AveragePrice:C}.");
            }
        }
    }
}