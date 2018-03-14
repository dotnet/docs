using System.Linq;
using System;
using System.Collections.Generic;

namespace Restriction
{
    public class WhereClause2
    {
        //This sample uses the where clause to find all products that are out of stock using query syntax.
        //Outputs the following to Console 
        //
        // Sold out products:
        // Chef Anton's Gumbo Mix is sold out!
        // Alice Mutton is sold out!
        // Thuringer Rostbratwurst is sold out!
        // Gorgonzola Telino is sold out!
        // Perth Pasties is sold out!
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var soldOutProducts =
                from prod in products
                where prod.UnitsInStock == 0
                select prod;

            Console.WriteLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                Console.WriteLine("{0} is sold out!", product.ProductName);
            }
        }

        //This sample uses the where clause to find all products that are out of stock using query syntax.
        //Outputs the following to Console 
        //
        // Sold out products:
        // Chef Anton's Gumbo Mix is sold out!
        // Alice Mutton is sold out!
        // Thuringer Rostbratwurst is sold out!
        // Gorgonzola Telino is sold out!
        // Perth Pasties is sold out!
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var soldOutProducts = products.Where(prod => prod.UnitsInStock == 0);
            
            Console.WriteLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                Console.WriteLine("{0} is sold out!", product.ProductName);
            }
        }
        
    }
}