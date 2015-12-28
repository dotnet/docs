using System;
using System.Collections.Generic;
using System.Linq;

namespace Concatenation 
{
    public class Concat2
    {
        //This sample uses Concat to create one sequence that contains each array's values, one after the other.
        // Outputs to the console 81 items:
        // Customer and product names:
        //  Joe's Pizza
        //  ...
        //  Original Frankfurter grune Sobe
        public static void QuerySyntaxExample()
        {
            List<Customer> customers = Data.Customers; 
            List<Product> products = Data.Products; 
  
            var customerNames = 
                from c in customers 
                select c.CustomerName; 

            var productNames = 
                from p in products 
                select p.ProductName;  

            var allNames = customerNames.Concat(productNames); 

            Console.WriteLine("Customer and product names:"); 
            foreach (var n in allNames) 
            { 
                Console.WriteLine(n); 
            }
        }

        //This sample uses Concat to create one sequence that contains each array's values, one after the other.
        // Outputs to the console 81 items:
        // Customer and product names:
        //  Joe's Pizza
        //  ...
        //  Original Frankfurter grune Sobe
        public static void MethodSyntaxExample()
        {
            List<Customer> customers = Data.Customers; 
            List<Product> products = Data.Products; 
  
            var customerNames = customers.Select(c => c.CustomerName); 
            var productNames = products.Select(p => p.ProductName);
            
            var allNames = customerNames.Concat(productNames); 
        
            Console.WriteLine("Customer and product names:"); 
            foreach (var n in allNames) 
            { 
                Console.WriteLine(n); 
            }
        }
    }
}
