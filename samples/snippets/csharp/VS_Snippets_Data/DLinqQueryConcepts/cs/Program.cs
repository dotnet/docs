using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_queryconcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet2>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            db.DeferredLoadingEnabled = false;

            IQueryable<Customer> custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (Customer custObj in custQuery)
            {
                foreach (Order ordObj in custObj.Orders)
                {
                    ProcessCustomerOrder(ordObj);
                }
            }
            // </Snippet2>
        }

        public static void ProcessCustomerOrder(Order ord)
        {
            // ...
        }

        void method1()
        {
            // <Snippet1>
            Northwnd db = new Northwnd(@"northwnd.mdf");

            IQueryable<Order> notificationQuery =
            from ord in db.Orders
         where ord.ShipVia == 3
          select ord;

            foreach (Order ordObj in notificationQuery)
            {
                if (ordObj.Freight > 200)
                    SendCustomerNotification(ordObj.Customer);
                ProcessOrder(ordObj);
            }
        }
        // </Snippet1>

        public void SendCustomerNotification(Customer ord)
        {
        }

        public void ProcessOrder(Order ord)
        {
        }

        void method3()
        {
            // <Snippet3>
            Northwnd db = new Northwnd(@"northwnd.mdf");

            IQueryable<Order> londonOrderQuery =
    from ord in db.Orders
    where ord.Customer.City == "London"
    select ord;
            // </Snippet3>
        }

        void method4()
        {
            // <Snippet4>
            Northwnd db = new Northwnd(@"northwnd.mdf");
            IQueryable<Order> londonOrderQuery =
    from cust in db.Customers
    join ord in db.Orders on cust.CustomerID equals ord.CustomerID
    where cust.City == "London"
    select ord;
            // </Snippet4>
        }

        void method5()
        {
            // <Snippet5>
            Northwnd db = new Northwnd(@"northwnd.mdf");
            var idQuery =
    from cust in db.Customers
    from ord in cust.Orders
    where cust.City == "London"
    select new { cust.CustomerID, ord.OrderID };
            // </Snippet5>
        }

        void method6()
        {
            // <Snippet6>
            Northwnd db = new Northwnd(@"northwnd.mdf");
            var idQuery =
    from ord in db.Orders
    where ord.Customer.City == "London"
    select new { ord.Customer.CustomerID, ord.OrderID };
            // </Snippet6>
        }

        void method7()
        {
            // <Snippet7>
            Northwnd db = new Northwnd(@"northwnd.mdf");
            Customer c = db.Customers.Single(x => x.CustomerID == "19283");
foreach (Order ord in
    c.Orders.Where(o => o.ShippedDate.Value.Year == 1998))
{
    // Do something.
}
            // </Snippet7>
        }

        void method8()
        {
            // <Snippet8>
            Northwnd db = new Northwnd(@"northwnd.mdf");
            Customer c = db.Customers.Single(x => x.CustomerID == "19283");
c.Orders.Load();

foreach (Order ord in
    c.Orders.Where(o => o.ShippedDate.Value.Year == 1998))
{
    // Do something.
}
        }
        // </Snippet8>

        void method9()
        {
            // <Snippet9>
            Northwnd db = new Northwnd(@"northwnd.mdf");
            DataLoadOptions ds = new DataLoadOptions();
            ds.LoadWith<Customer>(c => c.Orders);
            ds.LoadWith<Order>(o => o.OrderDetails);
            db.LoadOptions = ds;

            var custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (Customer custObj in custQuery)
            {
                Console.WriteLine($"Customer ID: {custObj.CustomerID}");
                foreach (Order ord in custObj.Orders)
                {
                    Console.WriteLine($"\tOrder ID: {ord.OrderID}");
                    foreach (OrderDetail detail in ord.OrderDetails)
                    {
                        Console.WriteLine($"\t\tProduct ID: {detail.ProductID}");
                    }
                }
            }
            // </Snippet9>
        }

        void method10()
        {
            // <Snippet10>
            Northwnd db = new Northwnd(@"northwnd.mdf");
            // Preload Orders for Customer.
            // One directive per relationship to be preloaded.
            DataLoadOptions ds = new DataLoadOptions();
            ds.LoadWith<Customer>(c => c.Orders);
            ds.AssociateWith<Customer>
                (c => c.Orders.Where(p => p.ShippedDate != DateTime.Today));
            db.LoadOptions = ds;

            var custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach (Customer custObj in custQuery)
            {
                Console.WriteLine($"Customer ID: {custObj.CustomerID}");
                foreach (Order ord in custObj.Orders)
                {
                    Console.WriteLine($"\tOrder ID: {ord.OrderID}");
                    foreach (OrderDetail detail in ord.OrderDetails)
                    {
                        Console.WriteLine($"\t\tProduct ID: {detail.ProductID}");
                    }
                }
            }
            // </Snippet10>
        }
    }
}
