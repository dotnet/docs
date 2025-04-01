using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace cs_querying
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // Query for customers in London.
            IQueryable<Customer> custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;
            // </Snippet1>
        }

        void method2()
        {
            // <Snippet2>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            db.ObjectTrackingEnabled = false;
            IOrderedQueryable<Employee> hireQuery =
                from emp in db.Employees
                orderby emp.HireDate
                select emp;

            foreach (Employee empObj in hireQuery)
            {
                Console.WriteLine("EmpID = {0}, Date Hired = {1}",
                    empObj.EmployeeID, empObj.HireDate);
            }
            // </Snippet2>
        }

        void method3()
        {
            // <Snippet3>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            db.DeferredLoadingEnabled = false;

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
            // </Snippet3>
        }

        void method4()
        {
            // <Snippet4>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            IEnumerable<Customer> results = db.ExecuteQuery<Customer>
            (@"SELECT c1.custid as CustomerID, c2.custName as ContactName
                FROM customer1 as c1, customer2 as c2
                WHERE c1.custid = c2.custid"
            );
            // </Snippet4>
        }

        void method5()
        {
            // <Snippet5>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            IEnumerable<Customer> results = db.ExecuteQuery<Customer>
                ("SELECT contactname FROM customers WHERE city = {0}",
                "London");
            // </Snippet5>
        }

        public Northwnd GetNorthwind()
        {
            Northwnd x = null ;
            return x;
        }

        // <Snippet7>
        // The following example invokes such a compiled query in the main
        // program.

        public IEnumerable<Customer> GetCustomersByCity(string city)
        {
            var myDb = GetNorthwind();
            return Queries.CustomersByCity(myDb, city);
        }
        // </Snippet7>
    }

    static class Queries
    {
        // <Snippet6>
        public static Func<Northwnd, string, IQueryable<Customer>>
            CustomersByCity =
                CompiledQuery.Compile((Northwnd db, string city) =>
                    from c in db.Customers where c.City == city select c);

        public static Func<Northwnd, string, IQueryable<Customer>>
            CustomersById = CompiledQuery.Compile((Northwnd db,
            string id) => db.Customers.Where(c => c.CustomerID == id));
        // </Snippet6>
    }

    // <Snippet8>
    class SimpleCustomer
    {
        public string ContactName { get; set; }
    }

    class Queries2
    {
        public static Func<Northwnd, string, IEnumerable<SimpleCustomer>> CustomersByCity =
            CompiledQuery.Compile<Northwnd, string, IEnumerable<SimpleCustomer>>(
            (Northwnd db, string city) =>
            from c in db.Customers
            where c.City == city
            select new SimpleCustomer { ContactName = c.ContactName });
    }
    // </Snippet8>
}
