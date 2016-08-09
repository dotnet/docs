using System.Linq;
using System;

namespace SetOperators
{
    public class SetUnion1
    {
        //This sample uses Union to create one sequence that contains the unique values from both arrays.
        //Outputs the following to Console 
        //  Unique numbers from both arrays:
        //   0
        //   2
        //   4
        //   5
        //   6
        //   8
        //   9
        //   1
        //   3
        //   7
       public static void MethodSyntaxExample() 
        { 
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 }; 

            var uniqueNumbers = numbersA.Union(numbersB); 

            Console.WriteLine("Unique numbers from both arrays:"); 
            foreach (var n in uniqueNumbers) 
            { 
                Console.WriteLine(n); 
            }
        }
    }
}
