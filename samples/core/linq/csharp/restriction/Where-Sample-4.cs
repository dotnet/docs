using System.Linq;
using System;
namespace Restriction
{
    //This sample demonstrates an indexed where clause that returns digits whose name is
    //shorter than their value.
    //Outputs the following to Console 
    //
    // Short digits:
    // The word five is shorter than its value.
    // The word six is shorter than its value.
    // The word seven is shorter than its value.
    // The word eight is shorter than its value.
    // The word nine is shorter than its value.
    public class WhereClause4
    {
        public static void Example()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, index) => digit.Length < index);

            Console.WriteLine("Short digits:");
            foreach (var d in shortDigits)
            {
                Console.WriteLine("The word {0} is shorter than its value.", d);
            }
        }
    }
}