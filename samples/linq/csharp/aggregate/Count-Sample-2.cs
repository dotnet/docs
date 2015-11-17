using System.Linq;
using System;

namespace Aggregate
{
    public static class CountSample2
    {
        //This sample uses Count to get the number of odd ints in the array. 
        // 
        //Output: 
        // There are 5 odd numbers in the list.
        public static void Example()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int oddNumbers = numbers.Count(n => n%2 == 1);

            Console.WriteLine($"There are {oddNumbers} odd numbers in the list.");
        }
    }
}