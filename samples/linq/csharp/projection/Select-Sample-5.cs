using System.Linq;
using System;
namespace Projection
{
    public class SelectSample5
    {
        //This sample uses select and query syntax to produce a sequence containing text representations of digits and
        //whether their length is even or odd.
        //
        //Outputs:
        // The digit five is odd.
        // The digit four is even.
        // The digit one is odd.
        // The digit three is odd.
        // The digit nine is odd.
        // The digit eight is even.
        // The digit six is even.
        // The digit seven is odd.
        // The digit two is even.
        // The digit zero is even.
        public static void QuerySyntaxExample()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens =
                from n in numbers
                select new { Digit = strings[n], Even = (n % 2 == 0) };

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}.");
            }
        }

        //This sample uses select to produce a sequence containing text representations of digits and
        //whether their length is even or odd.
        //
        //Outputs:
        // The digit five is odd.
        // The digit four is even.
        // The digit one is odd.
        // The digit three is odd.
        // The digit nine is odd.
        // The digit eight is even.
        // The digit six is even.
        // The digit seven is odd.
        // The digit two is even.
        // The digit zero is even.
        public static void MethodSyntaxExample()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens = numbers.Select(n => new {Digit = strings[n], Even = (n%2 == 0)});

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}.");
            }
        }
    }
}