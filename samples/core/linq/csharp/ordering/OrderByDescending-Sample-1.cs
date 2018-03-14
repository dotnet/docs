using System;
using System.Linq;

namespace Ordering
{
    public class OrderByDescending1
    {
        //This sample uses orderby and descending to sort a list of doubles from highest to lowest.
        //Outputs to the console: 
        //  The doubles from highest to lowest:
        //  4.1
        //  2.9
        //  2.3
        //  1.9
        //  1.7
        public static void QuerySyntaxExample()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 }; 
  
            var sortedDoubles = 
                from d in doubles 
                orderby d descending 
                select d; 
        
            Console.WriteLine("The doubles from highest to lowest:"); 
            foreach (var d in sortedDoubles) 
            { 
                Console.WriteLine(d); 
            }
        } 
        //This sample uses orderby and descending to sort a list of doubles from highest to lowest.
        //Outputs to the console: 
        //  The doubles from highest to lowest:
        //  4.1
        //  2.9
        //  2.3
        //  1.9
        //  1.7
        public static void MethodSyntaxExample()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 }; 
  
            var sortedDoubles = doubles.OrderByDescending(d => d); 

            Console.WriteLine("The doubles from highest to lowest:"); 
            foreach (var d in sortedDoubles) 
            { 
                Console.WriteLine(d); 
            }
        } 
    }
}