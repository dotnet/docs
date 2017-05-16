using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_objectidentity
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet1>
            Customer cust1 =
                (from cust in db.Customers
                 where cust.CustomerID == "BONAP"
                 select cust).First();

            Customer cust2 =
                (from cust in db.Customers
                 where cust.CustomerID == "BONAP"
                 select cust).First();
            // </Snippet1>

        
        }

        void method2()
        {
        
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            
            // <Snippet2>
            Customer cust1 =
                (from cust in db.Customers
                 where cust.CustomerID == "BONAP"
                 select cust).First();

            Customer cust2 =
                (from ord in db.Orders
                 where ord.Customer.CustomerID == "BONAP"
                 select ord).First().Customer;
            // </Snippet2>
        

        }
    }
}
