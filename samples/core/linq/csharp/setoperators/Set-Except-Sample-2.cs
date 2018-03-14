using System.Linq;
using System;
using System.Collections.Generic;

namespace SetOperators
{
    public class SetExcept2
    {
        //This sample uses Except to create one sequence that contains the first letters 
        // of product names that are not also first letters of customer names.
        //Outputs the following to Console 
        //   First letters from Product names, but not from Customer names:
        //   C
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
        //   Z
       public static void MethodSyntaxExample() 
        { 
            List<Product> products = Data.Products; 
            List<Customer> customers = Data.Customers; 

            var productFirstChars = products.Select(p=> p.ProductName[0]);
            var customerFirstChars = customers.Select(c=> c.CustomerName[0]); 

            var productOnlyFirstChars = productFirstChars.Except(customerFirstChars); 

            Console.WriteLine("First letters from Product names, but not from Customer names:"); 
            foreach (var ch in productOnlyFirstChars) 
            { 
                Console.WriteLine(ch); 
            } 

        }
    }
}
