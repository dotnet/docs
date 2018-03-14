using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_overridedefaultsproc
{
    class Program
    {

        void method5()
        {
            // <Snippet5>
            NorthwindThroughSprocs db = new NorthwindThroughSprocs("...");
            // Use a method call (stored procedure wrapper) instead of
            // a LINQ query against the database.
            var custQuery =
                db.CustomersByCity("London");

            foreach (Customer custObj in custQuery)
            {
                // Deferred loading of custObj.Orders uses the override
                // LoadOrders. There is no dynamic SQL.
                foreach (Order ord in custObj.Orders)
                {
                    // Make some changes to customers/orders.
                    // Overrides for Customer are called during the execution
                    // of the following.
                }
            }
            db.SubmitChanges();
            // </Snippet5>

        }

        static void Main(string[] args)
        {
            // <Snippet3>
            NorthwindThroughSprocs db = new NorthwindThroughSprocs("");
            var custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (Customer custObj in custQuery)
                // deferred loading of cust.Orders uses the override LoadOrders.
                foreach (Order ord in custObj.Orders)
                    // ...
                    // Make some changes to customers/orders.
                    // Overrides for Customer are called during the execution of the
                    // following:
                    db.SubmitChanges();
            // </Snippet3>
        }
    }
}
