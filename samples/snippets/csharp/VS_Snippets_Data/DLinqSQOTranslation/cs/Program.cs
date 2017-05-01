using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_sqotranslation
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet1>
            var custQuery = 
                (from cust in db.Customers
                where cust.City == "London"
                orderby cust.CustomerID
                select cust).Skip(1).Take(1);
            // </Snippet1>
        }

        void method2()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet2>
            db.Customers.GroupBy(c => c);
            db.Customers.GroupBy(c => new { c.CustomerID, c.ContactName });
            // </Snippet2>
        }

        void method3()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet3>
            db.Customers.Select(c => c);
            db.Customers.Select(c => new { c.CustomerID, c.City });
            db.Orders.Select(o => new { o.OrderID, o.Customer.City });
            db.Orders.Select(o => new { o.OrderID, o.Customer });	
            // </Snippet3>
        }

        void method4()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet4>
            // In the following line, c.Orders is a sequence.
            db.Customers.Select(c => new { c.CustomerID, c.Orders });
            // In the following line, the result has a sequence.
            db.Customers.GroupBy(c => c.City);
            // </Snippet4>
        }
    }
}
