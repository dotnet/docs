using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace cs_DataContext
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf)");

            // <Snippet1>
            if (!db.DatabaseExists())
                db.CreateDatabase();
            // …
            db.DeleteDatabase();
            // </Snippet1>
        }

        void method1()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf)");

            // <Snippet2>
            db.Log = Console.Out;
            var custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (var custObj in custQuery)
            {
                Console.WriteLine(custObj.ContactName);
            }
            // </Snippet2>

            Console.ReadLine();
        }
    }
}
