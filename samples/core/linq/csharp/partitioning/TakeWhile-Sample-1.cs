using System;
using System.Linq;

namespace Partitioning
{
    public static class TakeWhileSample1
    {
        //This sample uses TakeWhile to return elements starting from the beginning of the array
        //until a number is read whose value is not less than 6. 
        // 
        //Output: 
        // First numbers less than 6:
        // 5
        // 4
        // 1
        // 3
        public static void Example()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:");
            foreach (var num in firstNumbersLessThan6)
            {
                Console.WriteLine(num);
            }
        }
    }
}