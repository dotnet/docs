using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_cascadeworkaround
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            db.Log = Console.Out;

            // Specify order to be removed from database
            int reqOrder = 10250;

            // Fetch OrderDetails for requested order.
            var ordDetailQuery =
                from odq in db.OrderDetails
                where odq.OrderID == reqOrder
                select odq;

            foreach (var selectedDetail in ordDetailQuery)
            {
                Console.WriteLine(selectedDetail.Product.ProductID);
                db.OrderDetails.DeleteOnSubmit(selectedDetail);
            }

            // Display progress.
            Console.WriteLine("detail section finished.");
            Console.ReadLine();

            // Determine from Detail collection whether parent exists.
            if (ordDetailQuery.Any())
            {
                Console.WriteLine("The parent is present in the Orders collection.");
                // Fetch Order.
                try
                {
                    var ordFetch =
                        (from ofetch in db.Orders
                         where ofetch.OrderID == reqOrder
                         select ofetch).First();
                    db.Orders.DeleteOnSubmit(ordFetch);
                    Console.WriteLine("{0} OrderID is marked for deletion.", ordFetch.OrderID);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("There was no parent in the Orders collection.");
            }

            // Display progress.
            Console.WriteLine("Order section finished.");
            Console.ReadLine();

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            // Display progress.
            Console.WriteLine("Submit finished.");
            Console.ReadLine();
            // </Snippet1>
        }
    }
}
