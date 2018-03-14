using System;
using System.Linq;

namespace Aggregate
{
    public static class MaxSample1
    {
        //This sample uses Max to get the highest number in an array. Note that the method returns a single value.
        //
        //Outputs:
        // The maximum number is 9.
        public static void Example()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int maxNum = numbers.Max();

            Console.WriteLine($"The maximum number is {maxNum}.");
        }
    }
}