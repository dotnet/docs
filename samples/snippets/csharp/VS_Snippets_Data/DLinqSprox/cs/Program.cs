using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_sprox
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet3>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            decimal? totalSales = 0;
            db.CustOrderTotal("alfki", ref totalSales);

            Console.WriteLine(totalSales);
            // </Snippet3>
        }

        void CallMultiple()
        {
            // <Snippet5>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // Assign the results of the procedure with an argument
            // of (1) to local variable 'result'.
            IMultipleResults result = db.VariableResultShapes(1);

            // Iterate through the list and write results (the company names)
            // to the console.
            foreach(VariableResultShapesResult1 compName in
                result.GetResult<VariableResultShapesResult1>())
            {
                Console.WriteLine(compName.CompanyName);
            }

            // Pause to view company names; press Enter to continue.
            Console.ReadLine();
            
            // Assign the results of the procedure with an argument
            // of (2) to local variable 'result'.
            IMultipleResults result2 = db.VariableResultShapes(2);

            // Iterate through the list and write results (the order IDs)
            // to the console.
            foreach (VariableResultShapesResult2 ord in
                result2.GetResult<VariableResultShapesResult2>())
            {
                Console.WriteLine(ord.OrderID);
            }
            // </Snippet5>
        }

        void method7seq()
        {
            // <Snippet7>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            IMultipleResults sprocResults =
                db.MultipleResultTypesSequentially();

            // First read products.
            foreach (Product prod in sprocResults.GetResult<Product>())
            {
                Console.WriteLine(prod.ProductID);
            }

            // Next read customers.
            foreach (Customer cust in sprocResults.GetResult<Customer>())
            {
                Console.WriteLine(cust.CustomerID);
            }
            // </Snippet7>

        }
    }
}
