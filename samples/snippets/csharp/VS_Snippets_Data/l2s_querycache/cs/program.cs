using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2S_QueryCache
{
    class Program
    {
        static void Main(string[] args)
        {
            //<snippet1>
            NorthwindDataContext context = new NorthwindDataContext();

            // This query does not retrieve an object from
            // the query cache because it is the first query.
            // There are no objects in the cache.
            var a = context.Customers.First();
            Console.WriteLine($"First query gets customer {a.CustomerID}. ");

            // This query returns an object from the query cache.
            var b = context.Customers.Where(c => c.CustomerID == a.CustomerID);
            foreach (var customer in b )
            {
                Console.WriteLine(customer.CustomerID);
            }

            // This query returns an object from the identity cache.
            // Note that calling FirstOrDefault(), Single(), or SingleOrDefault()
            // instead of First() will also return an object from the cache.
            var x = context.Customers.
                Where(c => c.CustomerID == a.CustomerID).
                First();
            Console.WriteLine(x.CustomerID);

            // This query returns an object from the identity cache.
            // Note that calling FirstOrDefault(), Single(), or SingleOrDefault()
            // instead of First() (each with the same predicate) will also
            // return an object from the cache.
            var y = context.Customers.First(c => c.CustomerID == a.CustomerID);
            Console.WriteLine(y.CustomerID);
            //</snippet1>

            //<snippet3>
            var z = context.Customers.
                Where(c => c.CustomerID == a.CustomerID).
                MyFirst();
            Console.WriteLine(z.CustomerID);
            //</snippet3>
        }
    }

    //<snippet2>
    static class MyQueryable
    {
        public static TSource MyFirst<TSource>(this IQueryable<TSource> source)
        {
            return source.First();
        }
    }
    //</snippet2>
}
