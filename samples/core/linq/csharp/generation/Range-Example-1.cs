using System.Linq;
using System;

namespace Generation
{
    public static class RangeExample1
    {
        //This sample uses Range and query syntax to generate a sequence of numbers from 100 to 109
        //that is used to find which numbers in that range are odd and even.
        //
        //Output: 
        // The number 100 is even.
        // The number 101 is odd.
        // The number 102 is even.
        // The number 103 is odd.
        // The number 104 is even.
        // The number 105 is odd.
        // The number 106 is even.
        // The number 107 is odd.
        // The number 108 is even.
        // The number 109 is odd.
        public static void QuerySyntaxExample()
        {
            var numbers =
                     from n in Enumerable.Range(100, 10)
                     select new { Number = n, OddEven = n % 2 == 1 ? "odd" : "even" };

            foreach (var n in numbers)
            {
                Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven);
            }
        }

        //This sample uses Range and method syntax to generate a sequence of numbers from 100 to 109
        //that is used to find which numbers in that range are odd and even.
        //
        //Output: 
        // The number 100 is even.
        // The number 101 is odd.
        // The number 102 is even.
        // The number 103 is odd.
        // The number 104 is even.
        // The number 105 is odd.
        // The number 106 is even.
        // The number 107 is odd.
        // The number 108 is even.
        // The number 109 is odd.
        public static void MethodSyntaxExample()
        {
            var numbers =
                Enumerable.Range(100, 10).Select(n => new {Number = n, OddEven = n%2 == 1 ? "odd" : "even"});

            foreach (var n in numbers)
            {
                Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven);
            }
        }
    }
}