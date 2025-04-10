using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Common;

namespace cs_debuggingsupport
{
    class Program
    {
        static void Main(string[] args)
        {

            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet1>
            db.Log = Console.Out;
            IQueryable<Customer> custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach(Customer custObj in custQuery)
            {
                Console.WriteLine(custObj.CustomerID);
            }
            // </Snippet1>
        }

        void method2()
        {
            // <Snippet2>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            var custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (Customer custObj in custQuery)
            {
                Console.WriteLine($"CustomerID: {custObj.CustomerID}");
                Console.WriteLine($"\tOriginal value: {custObj.City}");
                custObj.City = "Paris";
                Console.WriteLine($"\tUpdated value: {custObj.City}");
            }

            ChangeSet cs = db.GetChangeSet();
            Console.Write("Total changes: {0}", cs);
            // Freeze the console window.
            Console.ReadLine();

            db.SubmitChanges();
            // </Snippet2>
        }

        void method3()
        {
            // <Snippet3>
            // using System.Data.Common;
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            var q =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            Console.WriteLine("Customers from London:");
            foreach (var z in q)
            {
                Console.WriteLine($"\t {z.ContactName}");
            }

            DbCommand dc = db.GetCommand(q);
            Console.WriteLine($"\nCommand Text: \n{dc.CommandText}");
            Console.WriteLine($"\nCommand Type: {dc.CommandType}");
            Console.WriteLine($"\nConnection: {dc.Connection}");

            Console.ReadLine();
            // </Snippet3>
        }
    }
}
