using System.Linq;
using System;

namespace Aggregate
{
    public static class AggregateSample1
    {
        //This sample uses Aggregate to create a running product on the array that calculates the total product of all elements.
        //Output: 
        // Total product of all numbers: 88.33081
        public static void MethodSyntaxExample() 
        { 
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 }; 
            
            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

            Console.WriteLine($"Total product of all numbers: {product}");
        }
    }
}
