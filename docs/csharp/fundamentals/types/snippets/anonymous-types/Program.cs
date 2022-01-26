using System;
using System.Collections.Generic;
using System.Linq;

namespace anonymous_types
{
    class Product
    {
        public string? Color {get;set;}
        public  decimal Price {get;set;}
    }
    class Anonymous
    {
        static void Main()
        {
            // don't show this unless you add a bunch more
            // properties to the type. otherwise it obviates the
            // need for the anonymous type
            List<Product> products = new ()
            {
                new Product() { Color="Orange", Price=2.00M},
            };

            //<snippet81>
            var productQuery =
                from prod in products
                select new { prod.Color, prod.Price };

            foreach (var v in productQuery)
            {
                Console.WriteLine("Color={0}, Price={1}", v.Color, v.Price);
            }
            //</snippet81>

            // <Snippet02>
            var apple = new { Item = "apples", Price = 1.35 };
            var onSale = apple with { Price = 0.79 };
            Console.WriteLine(apple);
            Console.WriteLine(onSale);
            // </Snippet02>
        }
    }
}
