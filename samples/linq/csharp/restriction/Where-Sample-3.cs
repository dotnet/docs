using System.Linq;
using System;
using System.Collections.Generic;

namespace Restriction
{
    public class WhereClause3
    {
        //This sample uses the where clause using query syntax to find all products that are in stock and cost 
        //more than 50.00 per unit.
        //Outputs the following to Console 
        //
        // In-stock products that cost more than 50.00:
        // Mishi Kobe Niku is in stock and costs more than 50.00.
        // Carnarvon Tigers is in stock and costs more than 50.00.
        // Sir Rodney's Marmalade is in stock and costs more than 50.00.
        // Cote de Blaye is in stock and costs more than 50.00.
        // Manjimup Dried Apples is in stock and costs more than 50.00.
        // Raclette Courdavault is in stock and costs more than 50.00.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var expensiveInStockProducts =
                from prod in products
                where prod.UnitsInStock > 0 && prod.UnitPrice > 50.00M
                select prod;

            Console.WriteLine("In-stock products that cost more than 50.00:");
            foreach (var product in expensiveInStockProducts)
            {
                Console.WriteLine("{0} is in stock and costs more than 50.00.", product.ProductName);
            }
        }

        //This sample uses the where clause using method syntax to find all products that are in stock and cost 
        //more than 50.00 per unit.
        //Outputs the following to Console 
        //
        // In-stock products that cost more than 50.00:
        // Mishi Kobe Niku is in stock and costs more than 50.00.
        // Carnarvon Tigers is in stock and costs more than 50.00.
        // Sir Rodney's Marmalade is in stock and costs more than 50.00.
        // Cote de Blaye is in stock and costs more than 50.00.
        // Manjimup Dried Apples is in stock and costs more than 50.00.
        // Raclette Courdavault is in stock and costs more than 50.00.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var expensiveInStockProducts = products.Where(prod=>prod.UnitsInStock > 0 && prod.UnitPrice > 50.00M);
            
            Console.WriteLine("In-stock products that cost more than 50.00:");
            foreach (var product in expensiveInStockProducts)
            {
                Console.WriteLine("{0} is in stock and costs more than 50.00.", product.ProductName);
            }
        }
    }
}