using System;
using System.Linq;

namespace Ordering
{
    public class Reverse1
    {
        //This sample uses Reverse to create a list of all digits in the array whose 
        // second letter is 'i' that is reversed from the order in the original array.
        //Outputs to the console:
        //  A backwards list of the digits with a second character of 'i':
        //  nine
        //  eight
        //  six
        //  five
        public static void QuerySyntaxExample()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }; 

            var reversedIDigits = ( from d in digits 
                                    where d[1] == 'i' 
                                    select d
                                  ).Reverse(); 

            Console.WriteLine("A backwards list of the digits with a second character of 'i':"); 
            foreach (var d in reversedIDigits) 
            { 
                Console.WriteLine(d); 
            }
        }
        //This sample uses Reverse to create a list of all digits in the array whose 
        // second letter is 'i' that is reversed from the order in the original array.
        //Outputs to the console:
        //  A backwards list of the digits with a second character of 'i':
        //  nine
        //  eight
        //  six
        //  five
        public static void MethodSyntaxExample()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }; 

            var reversedIDigits = digits.Where(d => d[1]=='i').Reverse();

            Console.WriteLine("A backwards list of the digits with a second character of 'i':"); 
            foreach (var d in reversedIDigits) 
            { 
                Console.WriteLine(d); 
            }
        }
    }
}
