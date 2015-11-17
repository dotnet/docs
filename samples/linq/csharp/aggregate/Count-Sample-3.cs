using System.Linq;
using System;
using System.Collections.Generic;


namespace Aggregate
{
    public static class CountSample3
    {
        //This sample uses Count to return a list of customers and how many orders each has.
        // 
        //Output: 
        // Customer Joe's Pizza has 1 order(s).
        // Customer Alfreds Futterkiste has 2 order(s).
        // Customer Around the Horn has 3 order(s).
        // Customer Bottom-Dollar Markets has 4 order(s).
        public static void Example()
        {
            List<Customer> customers = Data.Customers;
            var orderCounts =
                from c in customers
                select new {Customer = c.CustomerName, OrderCount = c.Orders.Count()};

            foreach (var item in orderCounts)
            {
                Console.WriteLine($"Customer {item.Customer} has {item.OrderCount} order(s).");
            }
        }
    }
}