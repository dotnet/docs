using System.Linq;
using System;
using System.Collections.Generic;

namespace Projection
{
    public class SelectManySample4
    {
        //This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders.
        //This makes the query more efficient by not selecting and then discarding orders for customers outside of Washington.
        //
        //Output:
        // CustomerId=TRAIH OrderId = 10822
        // CustomerId=WHITC OrderId = 10861
        // CustomerId=WHITC OrderId = 10904
        // CustomerId=WHITC OrderId = 11032
        // CustomerId=WHITC OrderId = 11066
        public static void QuerySyntaxExample()
        {
            List<Customer> customers = Data.Customers;

            DateTime cutoffDate = new DateTime(2015, 1, 1);

            var orders =
                from c in customers
                where c.Region == "WA"
                from o in c.Orders
                where o.OrderDate >= cutoffDate
                select new { c.CustomerId, o.OrderId };
            foreach (var order in orders)
            {
                Console.WriteLine($"CustomerId={order.CustomerId} OrderId={order.OrderId}");
            }
        }

        //This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders.
        //This makes the query more efficient by not selecting and then discarding orders for customers outside of Washington.
        //
        //Output:
        // CustomerId=TRAIH OrderId = 10822
        // CustomerId=WHITC OrderId = 10861
        // CustomerId=WHITC OrderId = 10904
        // CustomerId=WHITC OrderId = 11032
        // CustomerId=WHITC OrderId = 11066
        public static void MethodSyntaxExample()
        {
            List<Customer> customers = Data.Customers;

            DateTime cutoffDate = new DateTime(2015, 1, 1);

            var orders =
                customers.Where(c => c.Region == "WA")
                    .SelectMany(c => c.Orders, (c, o) => new {c, o})
                    .Where(t => t.o.OrderDate >= cutoffDate)
                    .Select(t => new {t.c.CustomerId, t.o.OrderId});
            foreach (var order in orders)
            {
                Console.WriteLine($"CustomerId={order.CustomerId} OrderId={order.OrderId}");
            }
        }
    }
}