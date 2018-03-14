using System;
using System.Linq;

namespace Aggregate
{
    public static class MinSample1
    {
        //This sample uses Min to get the lowest number in an array.
        // 
        //Output: 
        // The minimum number is 0.
        public static void Example()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int minNum = numbers.Min();

            Console.WriteLine($"The minimum number is {minNum}.");
        }
    }
}