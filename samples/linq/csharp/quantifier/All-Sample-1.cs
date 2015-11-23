using System;
using System.Linq;

namespace Quantifier
{
    public class AllSample1
    {
        //This sample uses All to determine whether an array contains only odd numbers.
        //
        //Output:
        // The list contains only odd numbers: True
        public static void Example()
        {
            int[] numbers = {1, 11, 3, 19, 41, 65, 19};

            bool onlyOdd = numbers.All(n => n%2 == 1);

            Console.WriteLine("The list contains only odd numbers: {0}", onlyOdd);
        }
    }
}