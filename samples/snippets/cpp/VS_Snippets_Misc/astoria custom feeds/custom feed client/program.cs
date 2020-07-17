using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Custom_Feed_Client.Northwind;

namespace Custom_Feed_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //NorthwindEntities context = new NorthwindEntities(new Uri("http://localhost:12345/Northwind.svc"));
                NorthwindEntities context = new NorthwindEntities(new Uri("http://localhost:54321/Northwind.svc"));

                var cust = from customers in context.Customers
                           where customers.CustomerID == "ALFKI"
                           select customers;

                foreach (Customer c in cust)
                {
                    Console.WriteLine(c.CompanyName.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
