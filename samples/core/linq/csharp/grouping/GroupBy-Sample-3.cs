using System.Linq;
using System;
using System.Collections.Generic;

namespace Grouping
{
    public class GroupBy3
    {
        //This sample uses group by to partition a list of products by category.
        //Outputs to the console all products by category
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var orderGroups =
                from p in products
                group p by p.Category into g
                select new { Category = g.Key, Products = g };

            foreach (var i in orderGroups)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"Category={i.Category}:");
                foreach (var p in i.Products)
                {
                    var s = $"ProductID={p.ProductId}, Product Name={p.ProductName}, UnitPrice={p.UnitPrice}, UnitsInStock={p.UnitsInStock}";
                    Console.WriteLine(s);
                }
            }
        }
        //This sample uses group by to partition a list of products by category.
        //Outputs to the console all products by category
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var orderGroups = products.GroupBy(p => p.Category,
                 (Key, g) => new { Category = Key, Products = g });

            foreach (var i in orderGroups)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"Category={i.Category}:");
                foreach (var p in i.Products)
                {
                    var s = $"ProductID={p.ProductId}, Product Name={p.ProductName}, UnitPrice={p.UnitPrice}, UnitsInStock={p.UnitsInStock}";
                    Console.WriteLine(s);
                }
            }
        }
    }
}
