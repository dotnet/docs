using System.Linq;
using System;
using System.Collections.Generic;

namespace SetOperators
{
    public class SetExcept1
    {
        //This sample uses Except to create a sequence that contains 
        // the values from numbersAthat are not also in numbersB.
        //Outputs the following to Console 
        //  Numbers in first array but not second array:
        //   0
        //   2
        //   4
        //   6
        //   9
       public static void MethodSyntaxExample() 
        { 
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 }; 
            
            IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB); 
            
            Console.WriteLine("Numbers in first array but not second array:"); 
            foreach (var n in aOnlyNumbers) 
            { 
                Console.WriteLine(n); 
            } 
        }
    }
}
