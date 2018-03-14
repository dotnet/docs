using System;
using System.Linq;

namespace Ordering
{
    public class ThenBy1
    {
        //This sample uses a compound orderby to sort a list of digits, 
        // first by length of their name, and then alphabetically by the name itself.
        //Outputs to the console:
        // Sorted digits:
        //  one
        //  six
        //  two
        //  five
        //  four
        //  nine
        //  zero
        //  eight
        //  seven
        //  three
        public static void QuerySyntaxExample()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }; 

            var sortedDigits = 
                from d in digits 
                orderby d.Length, d 
                select d; 

            Console.WriteLine("Sorted digits:"); 
            foreach (var d in sortedDigits) 
            { 
                Console.WriteLine(d); 
            }
        }
        //This sample uses a compound orderby to sort a list of digits, 
        // first by length of their name, and then alphabetically by the name itself.
        //Outputs to the console:
        // Sorted digits:
        //  one
        //  six
        //  two
        //  five
        //  four
        //  nine
        //  zero
        //  eight
        //  seven
        //  three
        public static void MethodSyntaxExample()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }; 

            var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);
            
            Console.WriteLine("Sorted digits:"); 
            foreach (var d in sortedDigits) 
            { 
                Console.WriteLine(d); 
            }
        }
    }
}
