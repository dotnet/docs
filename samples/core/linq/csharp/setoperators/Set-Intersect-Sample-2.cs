using System.Linq;
using System;
using System.Collections.Generic;

namespace SetOperators
{
    public class SetIntersect2
    {
        //This sample uses Intersect to create one sequence that contains 
        // the common first letter from both product and customer names.
        //Outputs the following to Console 
        //  Common first letters from Product names and Customer names:
        //   A
        //   B
        //   J
       public static void MethodSyntaxExample() 
        { 
            List<Product> products = Data.Products;
            List<Customer> customers = Data.Customers; 
            
            var productFirstChars = products.Select(p=> p.ProductName[0]);
            var customerFirstChars = customers.Select(c=> c.CustomerName[0]); 
            var commonFirstChars = productFirstChars.Intersect(customerFirstChars); 
            
            Console.WriteLine("Common first letters from Product names and Customer names:"); 
            foreach (var ch in commonFirstChars) 
            { 
                Console.WriteLine(ch); 
            }
        }
    }
}
