using System;
using System.Linq;

namespace Concatenation 
{
    public class Concat1
    {
        //This sample uses Concat to create one sequence that contains each array's values, one after the other.
        // Outputs to the console:
        //  All numbers from both arrays: 
        //  0 
        //  2 
        //  4 
        //  5 
        //  6 
        //  8 
        //  9 
        //  1 
        //  3 
        //  5 
        //  7 
        //  8
        public static void MethodSyntaxExample()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 }; 
        
            var allNumbers = numbersA.Concat(numbersB); 
        
            Console.WriteLine("All numbers from both arrays:"); 
            foreach (var n in allNumbers) 
            { 
                Console.WriteLine(n); 
            }
        }
    }
}
