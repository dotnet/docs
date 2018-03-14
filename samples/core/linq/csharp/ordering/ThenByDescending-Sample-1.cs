using System;
using System.Linq;
using System.Collections.Generic;

namespace Ordering
{
    public class ThenByDescending1
    {
        //This sample uses a compound orderby to sort a list of products, 
        // first by category, and then by unit price, from highest to lowest.
        //Outputs to the console 77 products:
        //ProductID=38, ProductName=Cote de Blaye, Category=Beverages, UnitPrice=$263.50
        // ... 
        //ProductID=13, ProductName=Konbu, Category=Seafood, UnitPrice=$6.00
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var sortedProducts = 
                from p in products 
                orderby p.Category, p.UnitPrice descending
                select p; 

            foreach (var p in sortedProducts) 
            {
                Console.WriteLine($"ProductId={p.ProductId}, ProductName={p.ProductName}, Category={p.Category}, UnitPrice={p.UnitPrice:C}"); 
            }
        } 
        //This sample uses a compound orderby to sort a list of products, 
        // first by category, and then by unit price, from highest to lowest.
        //Outputs to the console 77 products:
        //ProductID=38, ProductName=Cote de Blaye, Category=Beverages, UnitPrice=$263.50
        // ... 
        //ProductID=13, ProductName=Konbu, Category=Seafood, UnitPrice=$6.00
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var sortedProducts = products.OrderBy(p => p.Category)
                                         .ThenByDescending(p => p.UnitPrice);

            foreach (var p in sortedProducts) 
            {
                Console.WriteLine($"ProductId={p.ProductId}, ProductName={p.ProductName}, Category={p.Category}, UnitPrice={p.UnitPrice:C}"); 
            }
        }
    }
}
