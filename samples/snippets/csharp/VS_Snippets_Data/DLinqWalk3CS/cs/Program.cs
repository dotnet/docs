using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// <Snippet1>
using System.Data.Linq;
using System.Data.Linq.Mapping;
// </Snippet1>

namespace cs_walk3
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet2>
            // Use the following connection string.
            Northwnd db = new Northwnd(@"c:\linqtest6\northwnd.mdf");

            // Keep the console window open after activity stops.
            Console.ReadLine();
            // </Snippet2>
        }

        void method3()
        {
            Northwnd db = new Northwnd(@"c:\linqtest6\northwnd.mdf");

            // <Snippet3>
            // Create the new Customer object.
            Customer newCust = new Customer();
            newCust.CompanyName = "AdventureWorks Cafe";
            newCust.CustomerID = "ADVCA";

            // Add the customer to the Customers table.
            db.Customers.InsertOnSubmit(newCust);

            Console.WriteLine("\nCustomers matching CA before insert");

            foreach (var c in db.Customers.Where(cust => cust.CustomerID.Contains("CA")))
            {
                Console.WriteLine("{0}, {1}, {2}",
                    c.CustomerID, c.CompanyName, c.Orders.Count);
            }
            // </Snippet3>

        }

        void method4()
        {
            Northwnd db = new Northwnd(@"c:\linqtest6\northwnd.mdf");

            // <Snippet4>
            // Query for specific customer.
            // First() returns one object rather than a collection.
            var existingCust =
                (from c in db.Customers
                 where c.CustomerID == "ALFKI"
                 select c)
                .First();

            // Change the contact name of the customer.
            existingCust.ContactName = "New Contact";
            // </Snippet4>

            // <Snippet5>
            // Access the first element in the Orders collection.
            Order ord0 = existingCust.Orders[0];

            // Access the first element in the OrderDetails collection.
            OrderDetail detail0 = ord0.OrderDetails[0];

            // Display the order to be deleted.
            Console.WriteLine
                ("The Order Detail to be deleted is: OrderID = {0}, ProductID = {1}",
                detail0.OrderID, detail0.ProductID);

            // Mark the Order Detail row for deletion from the database.
            db.OrderDetails.DeleteOnSubmit(detail0);
            // </Snippet5>

            // <Snippet6>
            db.SubmitChanges();
            // </Snippet6>

            // <Snippet7>
            Console.WriteLine("\nCustomers matching CA after update");
            foreach (var c in db.Customers.Where(cust =>
                cust.CustomerID.Contains("CA")))
            {
                Console.WriteLine("{0}, {1}, {2}",
                    c.CustomerID, c.CompanyName, c.Orders.Count);
            }
            // </Snippet7>

        }

        
    }
}
