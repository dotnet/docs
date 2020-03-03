using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_crudops
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            Northwnd db = new Northwnd(@"c:\Northwnd.mdf");

            // Query for a specific customer.
            var cust =
                (from c in db.Customers
                 where c.CustomerID == "ALFKI"
                 select c).First();

            // Change the name of the contact.
            cust.ContactName = "New Contact";

            // Create and add a new Order to the Orders collection.
            Order ord = new Order { OrderDate = DateTime.Now };
            cust.Orders.Add(ord);

            // Delete an existing Order.
            Order ord0 = cust.Orders[0];

            // Removing it from the table also removes it from the Customer’s list.
            db.Orders.DeleteOnSubmit(ord0);

            // Ask the DataContext to save all the changes.
            db.SubmitChanges();
            // </Snippet1>
        }
    }
}
