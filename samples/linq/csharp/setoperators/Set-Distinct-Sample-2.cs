using System.Linq;
using System;
using System.Collections.Generic;

namespace SetOperators
{
    public class SetDistinct2
    {
        //This sample uses Distinct to find the unique Category names.
        //Outputs the following to Console 
        //  Category names:
        //   Beverages
        //   Condiments
        //   Produce
        //   Meat/Poultry
        //   Seafood
        //   Dairy Products
        //   Confections
        //   Grains/Cereals
        public static void QuerySyntaxExample() 
        { 
            List<Product> products = Data.Products; 
  
            var categoryNames = ( 
                from p in products 
                select p.Category).Distinct(); 
            
            Console.WriteLine("Category names:"); 
            foreach (var n in categoryNames) 
            {
                Console.WriteLine(n); 
            }
        }
        //This sample uses Distinct to find the unique Category names.
        //Outputs the following to Console 
        //  Category names:
        //   Beverages
        //   Condiments
        //   Produce
        //   Meat/Poultry
        //   Seafood
        //   Dairy Products
        //   Confections
        //   Grains/Cereals
        public static void MethodSyntaxExample() 
        { 
            List<Product> products = Data.Products; 
  
            var categoryNames = products.Select(p=> p.Category).Distinct(); 
            
            Console.WriteLine("Category names:"); 
            foreach (var n in categoryNames) 
            {
                Console.WriteLine(n); 
            }
        }
    }
}
