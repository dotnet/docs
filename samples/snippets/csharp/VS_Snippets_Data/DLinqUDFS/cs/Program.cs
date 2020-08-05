using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_udfs
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd("");

            // <Snippet2>
            var q =
    from p in db.ProductsCostingMoreThan(80.50m)
    join s in db.Products on p.ProductID equals s.ProductID
    select new { p.ProductID, s.UnitPrice };
            // </Snippet2>
        }

        void method4()
        {
            Northwnd db = new Northwnd("");
            // <Snippet4>
            string str = db.ReverseCustName("LINQ to SQL");
            // </Snippet4>
        }

        void method5()
        {
            Northwnd db = new Northwnd("");
            // <Snippet5>
            var custQuery =
                from cust in db.Customers
                select new {cust.ContactName, Title =
                    db.ReverseCustName(cust.ContactTitle)};
            // </Snippet5>
        }
    }
}
