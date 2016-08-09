using System;
using System.Linq;
using System.Collections.Generic;

namespace Ordering
{
    public class OrderBy3
    {
        //This sample uses orderby to sort a list of products by name.
        //Outputs to the console 77 products:
        //ProductID=17 ProductName=Alice Mutton Category=Meat/Poultry UnitPrice=$39.00
        // ... 
        //ProductId=47, ProductName=Zaanse koeken, Category=Confections, UnitPrice=$9.50
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var sortedProducts = 
                from p in products 
                orderby p.ProductName 
                select p; 

            foreach (var p in sortedProducts) 
            { 
                Console.WriteLine($"ProductId={p.ProductId}, ProductName={p.ProductName}, Category={p.Category}, UnitPrice={p.UnitPrice:C}"); 
            }
        } 
        //This sample uses orderby to sort a list of words by length.
        //Outputs to the console 77 products:
        //ProductID=17 ProductName=Alice Mutton Category=Meat/Poultry UnitPrice=$39.00
        // ... 
        //ProductId=47, ProductName=Zaanse koeken, Category=Confections, UnitPrice=$9.50
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;
        
            var sortedProducts = products.OrderBy(p => p.ProductName);

            foreach (var p in sortedProducts) 
            { 
                Console.WriteLine($"ProductId={p.ProductId}, ProductName={p.ProductName}, Category={p.Category}, UnitPrice={p.UnitPrice:C}"); 
            }
        }
    }
}
