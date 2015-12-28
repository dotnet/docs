using System.Linq;
using System;
using System.Collections.Generic;

namespace Projection
{
    public class SelectManySample5
    {
        //This sample uses an indexed SelectMany clause to select all orders, while referring to customers
        //by the order in which they are returned from the query.
        //
        //Output:
        // Customer #1 has an order with OrderId 10643
        // Customer #1 has an order with OrderId 10692
        // Customer #1 has an order with OrderId 10702
        // Customer #1 has an order with OrderId 10835
        // Customer #1 has an order with OrderId 10952
        // Customer #1 has an order with OrderId 11011
        // Customer #2 has an order with OrderId 10308
        // Customer #2 has an order with OrderId 10625
        // Customer #2 has an order with OrderId 10759
        // Customer #2 has an order with OrderId 10926
        // ...
        // Customer #91 has an order with OrderId 10792
        // Customer #91 has an order with OrderId 10870
        // Customer #91 has an order with OrderId 10906
        // Customer #91 has an order with OrderId 10998
        // Customer #91 has an order with OrderId 11044
        public static void Example()
        {
            List<Customer> customers = Data.Customers;

            var customerOrders =
                customers.SelectMany(
                    (cust, custIndex) =>
                    cust.Orders.Select(o => $"Customer # {custIndex + 1} has an order with OrderId {o.OrderId}"));
            foreach (var customerOrder in customerOrders)
            {
                Console.WriteLine(customerOrder);
            }
        }
    }
}