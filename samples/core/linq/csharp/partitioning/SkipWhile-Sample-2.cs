using System;
using System.Linq;

namespace Partitioning
{
    public static class SkipWhileSample2
    {
        //This sample uses SkipWhile to get the elements of the array starting from the first element less 
        //than its position.
        // 
        //Output: 
        // All elements starting from first element less than its position:
        // 1
        // 3
        // 9
        // 8
        // 6
        // 7
        // 2
        // 0
        public static void Example()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var laterNumbers = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine("All elements starting from first element less than its position:");
            foreach (var n in laterNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}