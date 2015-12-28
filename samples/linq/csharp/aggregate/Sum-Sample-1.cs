using System;
using System.Linq;

namespace Aggregate
{
    public static class SumSample1
    {
        //This sample uses Sum to add all the numbers in an array.
        // 
        // Output: 
        // The sum of the numbers is 45.
        public static void Example()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            double numSum = numbers.Sum();

            Console.WriteLine($"The sum of the numbers is {numSum}.");
        }
    }
}