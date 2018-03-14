using System;
using System.Collections.Generic;
using System.Linq;

namespace Element
{
    public static class FirstOrDefaultSample2
    {
        //This sample uses FirstOrDefault to return the first product whose ProductID is 789
        //as a single Product object, unless there is no match, in which case null is returned.
        //
        //Output: 
        // Product 789 exists: False
        public static void Example()
        {
            List<Product> products = Data.Products;

            Product product789 = products.FirstOrDefault(p => p.ProductId == 789);

            Console.WriteLine("Product 789 exists: {0}", product789 != null);
        }
    }
}