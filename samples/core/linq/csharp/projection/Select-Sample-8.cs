using System.Linq;
using System;
namespace Projection
{
    public class SelectSample8
    {
        //This sample combines select and where using query syntaxto make a simple query that returns the
        //text form of each digit less than 5.
        //
        //Outputs:
        // Numbers< 5:
        // four
        // one
        // three
        // two
        // zero
        public static void QuerySyntaxExample()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums =
                from n in numbers
                where n < 5
                select digits[n];

            Console.WriteLine("Numbers < 5:");
            foreach (var num in lowNums)
            {
                Console.WriteLine(num);
            }
        }

        //This sample combines select and where using query syntaxto make a simple query that returns the
        //text form of each digit less than 5.
        //
        //Outputs:
        // Numbers< 5:
        // four
        // one
        // three
        // two
        // zero
        public static void MethodSyntaxExample()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var lowNums = numbers.Where(n => n < 5).Select(n => digits[n]);

            Console.WriteLine("Numbers < 5:");
            foreach (var num in lowNums)
            {
                Console.WriteLine(num);
            }
        }

    }
}