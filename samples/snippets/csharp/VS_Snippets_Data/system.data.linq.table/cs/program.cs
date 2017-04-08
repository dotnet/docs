using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_insertonsubmit
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet1>
            // Create a new Order object.
            Order ord = new Order
            {
                OrderID = 12000,
                ShipCity = "Seattle",
                OrderDate = DateTime.Now
                // …
            };

            // Add the new object to the Orders collection.
            db.Orders.InsertOnSubmit(ord);

            // Submit the change to the database.
            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Make some adjustments.
                // ...
                // Try again.
                db.SubmitChanges();
            }
            // </Snippet1>

        }

        void methodUpdate()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet2>
            // Query the database for the row to be updated.
            var query =
                from ord in db.Orders
                where ord.OrderID == 11000
                select ord;

            // Execute the query, and change the column values
            // you want to change.
            foreach (Order ord in query)
            {
                ord.ShipName = "Mariner";
                ord.ShipVia = 2;
                // Insert any additional changes to column values.
            }

            // Submit the changes to the database.
            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            // </Snippet2>

        }

        void methodDelete()
        {

            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

// <Snippet3>
// Query the database for the rows to be deleted.
var deleteOrderDetails =
    from details in db.OrderDetails
    where details.OrderID == 11000
    select details;

foreach (var detail in deleteOrderDetails)
{
    db.OrderDetails.DeleteOnSubmit(detail);
}
                        
try
{
    db.SubmitChanges();
}
catch (Exception e)
{
    Console.WriteLine(e);
    // Provide for exceptions.
}
// </Snippet3>
        }
    }
}
