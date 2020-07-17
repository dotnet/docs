using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_localmethodcall
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"");

            // <Snippet1>
            // Query 1.
            var q1 =
                from ord in db.Orders
                where ord.EmployeeID == 9
                select ord;

            foreach (var ordObj in q1)
            {
                Console.WriteLine("{0}, {1}", ordObj.OrderID,
                    ordObj.ShipVia.Value);
            }
            // </Snippet1>
        }
    }
}
