using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_gettingstarted
{
    class Program
    {
        static void Main(string[] args)
        {

            // <Snippet1>
            // Northwnd inherits from System.Data.Linq.DataContext.
            Northwnd nw = new Northwnd(@"northwnd.mdf");
            // or, if you are not using SQL Server Express
            // Northwnd nw = new Northwnd("Database=Northwind;Server=server_name;Integrated Security=SSPI");

            var companyNameQuery =
                from cust in nw.Customers
                where cust.City == "London"
                select cust.CompanyName;

            foreach (var customer in companyNameQuery)
            {
                Console.WriteLine(customer);
            }
            // </Snippet1>

        }

        void method2()
        {
            // <Snippet2>
            // Northwnd inherits from System.Data.Linq.DataContext.
            Northwnd nw = new Northwnd(@"northwnd.mdf");

            Customer cust = new Customer();
            cust.CompanyName = "SomeCompany";
            cust.City = "London";
            cust.CustomerID = "98128";
            cust.PostalCode = "55555";
            cust.Phone = "555-555-5555";
            nw.Customers.InsertOnSubmit(cust);

            // At this point, the new Customer object is added in the object model.
            // In LINQ to SQL, the change is not sent to the database until
            // SubmitChanges is called.
            nw.SubmitChanges();
            // </Snippet2>
        }

        void method3()
        {
            // <Snippet3>
            Northwnd nw = new Northwnd(@"northwnd.mdf");
            
            var cityNameQuery =
                from cust in nw.Customers
                where cust.City.Contains("London")
                select cust;

            foreach (var customer in cityNameQuery)
            {
                if (customer.City == "London")
                {
                    customer.City = "London - Metro";
                }
            }
            nw.SubmitChanges();
            // </Snippet3>
        }

        void method4()
        {
            // <Snippet4>
            Northwnd nw = new Northwnd(@"northwnd.mdf");
            var deleteIndivCust =
                from cust in nw.Customers
                where cust.CustomerID == "98128"
                select cust;

            if (deleteIndivCust.Count() > 0)
            {
                nw.Customers.DeleteOnSubmit(deleteIndivCust.First());
                nw.SubmitChanges();
            }
            // </Snippet4>

        }
    }
}
