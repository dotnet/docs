using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace cs_adonet
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"");

            // <Snippet1>
            // Do not use System.Data.SqlClient for new development; use Microsoft.Data.SqlClient.
            // LINQ to SQL's built-in provider requires System.Data.SqlClient.
            db.Connection.Close();
            // </Snippet1>

            // <Snippet2>
            // Do not use System.Data.SqlClient for new development; use Microsoft.Data.SqlClient.
            // LINQ to SQL's built-in provider requires System.Data.SqlClient.
            using (TransactionScope ts = new TransactionScope())
            {
                db.SubmitChanges();
                ts.Complete();
            }
            // </Snippet2>

            // <Snippet3>
            // Do not use System.Data.SqlClient for new development; use Microsoft.Data.SqlClient.
            // LINQ to SQL's built-in provider requires System.Data.SqlClient.
            IEnumerable<Customer> results = db.ExecuteQuery<Customer>(
    @"select c1.custid as CustomerID, c2.custName as ContactName
        from customer1 as c1, customer2 as c2
        where c1.custid = c2.custid"
);
            // </Snippet3>
        }

        void another()
        {
            Northwnd db = new Northwnd(@"");

            // <Snippet4>
            // Do not use System.Data.SqlClient for new development; use Microsoft.Data.SqlClient.
            // LINQ to SQL's built-in provider requires System.Data.SqlClient.
            IEnumerable<Customer> results = db.ExecuteQuery<Customer>(
    "select contactname from customers where city = {0}",
    "London"
);
            // </Snippet4>
        }
    }
}
