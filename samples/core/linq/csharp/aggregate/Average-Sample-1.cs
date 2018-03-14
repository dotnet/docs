using System;
using System.Linq;

namespace Aggregate
{
    public static class AverageSample1
    {
        //This sample uses Average to get the average of all numbers in an array.
        //
        //Outputs:
        // The average number is 4.5.
        public static void Example()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double averageNum = numbers.Average();

            Console.WriteLine($"The average number is {averageNum}.");
        }
    }
}