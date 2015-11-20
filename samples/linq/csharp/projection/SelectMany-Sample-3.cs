using System.Linq;
using System;
using System.Collections.Generic;

namespace Projection
{
    public class SelectManySample3
    {
        //This sample uses a compound from clause and query syntax to select all orders
        //where the order was made in 2015-05 or later.
        //
        //Output:
        // CustomerId=BONAP OrderId = 11076 OrderDate=2015-05-06
        // CustomerId=DRACD OrderId = 11067 OrderDate=2015-05-04
        // CustomerId=ERNSH OrderId = 11072 OrderDate=2015-05-05
        // CustomerId=LEHMS OrderId = 11070 OrderDate=2015-05-05
        // CustomerId=LILAS OrderId = 11065 OrderDate=2015-05-01
        // CustomerId=LILAS OrderId = 11071 OrderDate=2015-05-05
        // CustomerId=PERIC OrderId = 11073 OrderDate=2015-05-05
        // CustomerId=QUEEN OrderId = 11068 OrderDate=2015-05-04
        // CustomerId=RATTC OrderId = 11077 OrderDate=2015-05-06
        // CustomerId=RICSU OrderId = 11075 OrderDate=2015-05-06
        // CustomerId=SAVEA OrderId = 11064 OrderDate=2015-05-01
        // CustomerId=SIMOB OrderId = 11074 OrderDate=2015-05-06
        // CustomerId=TORTU OrderId = 11069 OrderDate=2015-05-04
        // CustomerId=WHITC OrderId = 11066 OrderDate=2015-05-01
        public static void QuerySyntaxExample()
        {
            List<Customer> customers = Data.Customers;

            var orders =
                from c in customers
                from o in c.Orders
                where o.OrderDate >= new DateTime(2015, 5, 1)
                select new { c.CustomerId, o.OrderId, o.OrderDate };
            foreach (var order in orders)
            {
                Console.WriteLine($"CustomerId={order.CustomerId} OrderId={order.OrderId} OrderDate={order.OrderDate:yyyy-MM-dd}");
            }
        }

        //This sample uses a compound from clause and query syntax to select all orders
        //where the order was made in 2015-05 or later.
        //
        //Output:
        // CustomerId=BONAP OrderId = 11076 OrderDate=2015-05-06
        // CustomerId=DRACD OrderId = 11067 OrderDate=2015-05-04
        // CustomerId=ERNSH OrderId = 11072 OrderDate=2015-05-05
        // CustomerId=LEHMS OrderId = 11070 OrderDate=2015-05-05
        // CustomerId=LILAS OrderId = 11065 OrderDate=2015-05-01
        // CustomerId=LILAS OrderId = 11071 OrderDate=2015-05-05
        // CustomerId=PERIC OrderId = 11073 OrderDate=2015-05-05
        // CustomerId=QUEEN OrderId = 11068 OrderDate=2015-05-04
        // CustomerId=RATTC OrderId = 11077 OrderDate=2015-05-06
        // CustomerId=RICSU OrderId = 11075 OrderDate=2015-05-06
        // CustomerId=SAVEA OrderId = 11064 OrderDate=2015-05-01
        // CustomerId=SIMOB OrderId = 11074 OrderDate=2015-05-06
        // CustomerId=TORTU OrderId = 11069 OrderDate=2015-05-04
        // CustomerId=WHITC OrderId = 11066 OrderDate=2015-05-01
        public static void MethodSyntaxExample()
        {
            List<Customer> customers = Data.Customers;

            var orders =
                customers.SelectMany(c => c.Orders, (c, o) => new {c, o})
                    .Where(t => t.o.OrderDate >= new DateTime(2015, 5, 1))
                    .Select(t => new {t.c.CustomerId, t.o.OrderId, t.o.OrderDate});
            foreach (var order in orders)
            {
                Console.WriteLine($"CustomerId={order.CustomerId} OrderId={order.OrderId} OrderDate={order.OrderDate:yyyy-MM-dd}");
            }
        }
    }
}