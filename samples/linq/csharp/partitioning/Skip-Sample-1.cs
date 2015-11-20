using System;
using System.Linq;

namespace Partitioning
{
    public static class SkipSample1
    {
        //This sample uses Skip to get all but the first four elements of the array. 
        // 
        //Output: 
        // All but first 4 numbers:
        // 9
        // 8
        // 6
        // 7
        // 2
        // 0
        public static void Example()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");
            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}