using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_gettingstartedexpers
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.AssociateWith<Customer>(c => c.Orders.Where(p => p.ShippedDate != DateTime.Today));
            db.LoadOptions = dlo;
            var custOrderQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (Customer custObj in custOrderQuery)
            {
                Console.WriteLine(custObj.CustomerID);
                foreach (Order ord in custObj.Orders)
                {
                    Console.WriteLine($"\t {ord.OrderDate}");
                }
            }
            // </Snippet1>

            Console.ReadLine();
        }

        public void method2()
        {
            // <Snippet2>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Customer>(c => c.Orders);
            db.LoadOptions = dlo;

            var londonCustomers =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (var custObj in londonCustomers)
            {
                Console.WriteLine(custObj.CustomerID);
            }
            // </Snippet2>
        }
    }
}
