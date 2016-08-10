using System.Linq;
using System;

namespace Partitioning
{
    public static class TakeSample1
    {
        //This sample uses Take to get only the first 3 elements of the array. 
        // 
        //Output: 
        // First 3 numbers: 
        // 5 
        // 4 
        // 1
        public static void Example()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");
            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}