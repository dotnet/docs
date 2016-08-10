using System.Linq;
using System;
namespace Projection
{
    public class SelectSample3
    {
        //This sample uses select and query syntax to produce a sequence of strings representing the text version of a sequence of ints.
        //
        //Outputs:
        // Number strings:
        // five
        // four
        // one
        // three
        // nine
        // eight
        // six
        // seven
        // two
        // zero
        public static void QuerySyntaxExample()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums =
                from n in numbers
                select strings[n];

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }

        //This sample uses select and method syntax to produce a sequence of strings representing the text version of a sequence of ints.
        //
        //Outputs:
        // Number strings:
        // five
        // four
        // one
        // three
        // nine
        // eight
        // six
        // seven
        // two
        // zero
        public static void MethodSyntaxExample()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = numbers.Select(n => strings[n]);

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }
    }
}