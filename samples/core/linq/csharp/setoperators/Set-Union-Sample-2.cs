using System.Linq;
using System;
using System.Collections.Generic;

namespace SetOperators
{
    public class SetUnion2
    {
        //This sample uses Union to create one sequence that contains the 
        // unique first letter from both product and customer names.
        //Outputs the following to Console 
        //  Unique first letters from Product names and Customer names:
        //   C
        //   A
        //   G
        //   U
        //   N
        //   M
        //   I
        //   Q
        //   K
        //   T
        //   P
        //   S
        //   R
        //   B
        //   J
        //   Z
       public static void MethodSyntaxExample() 
        { 
            List<Product> products = Data.Products;
            List<Customer> customers = Data.Customers; 
            
            var productFirstChars = products.Select(p => p.ProductName[0]);
            var customerFirstChars =  customers.Select(c => c.CustomerName[0]);

            var uniqueFirstChars = productFirstChars.Union(customerFirstChars); 

            Console.WriteLine("Unique first letters from Product names and Customer names:"); 
            foreach (var ch in uniqueFirstChars) 
            { 
                Console.WriteLine(ch); 
            }
        }
    }
}
