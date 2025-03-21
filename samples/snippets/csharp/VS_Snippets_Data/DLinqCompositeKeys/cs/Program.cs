using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_compositekeys
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"northwnd.mdf");

            // <Snippet1>
            var query =
    from cust in db.Customers
    group cust.ContactName by new { City = cust.City, Region = cust.Region };

            foreach (var grp in query)
            {
                Console.WriteLine($"\nLocation Key: {grp.Key}");
                foreach (var listing in grp)
                {
                    Console.WriteLine($"\t{listing}");
                }
            }
            // </Snippet1>
        }

        void nextMethod()
        {
            Northwnd db = new Northwnd(@"northwnd.mdf");

            // <Snippet2>
            var query =
    from ord in db.Orders
    from prod in db.Products
    join det in db.OrderDetails
        on new { ord.OrderID, prod.ProductID } equals new { det.OrderID, det.ProductID }
        into details
    from det in details
    select new { ord.OrderID, prod.ProductID, det.UnitPrice };
            // </Snippet2>
        }
    }
}
