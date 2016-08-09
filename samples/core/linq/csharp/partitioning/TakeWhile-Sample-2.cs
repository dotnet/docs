using System;
using System.Linq;

namespace Partitioning
{
    public static class TakeWhileSample2
    {
        //This sample uses TakeWhile to return elements starting from the beginning of the array
        //until a number is hit that is less than its position in the array.
        // 
        //Output: 
        // First numbers not less than their position:
        // 5
        // 4
        public static void Example()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            Console.WriteLine("First numbers not less than their position:");
            foreach (var n in firstSmallNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}