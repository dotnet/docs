using System.Linq;
using System;

namespace SetOperators
{
    public class SetIntersect1
    {
        //This sample uses Intersect to create one sequence that contains 
        // the common values shared by both arrays.
        //Outputs the following to Console 
        //Common numbers shared by both arrays:
        // 5
        // 8
       public static void MethodSyntaxExample() 
        { 
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 }; 

            var commonNumbers = numbersA.Intersect(numbersB); 

            Console.WriteLine("Common numbers shared by both arrays:"); 
            foreach (var n in commonNumbers) 
            {
                Console.WriteLine(n); 
            }
        }
    }
}
