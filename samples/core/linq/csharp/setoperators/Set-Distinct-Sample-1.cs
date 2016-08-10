using System.Linq;
using System;
namespace SetOperators
{
    public class SetDistinct1
    {
        //This sample uses Distinct to remove duplicate elements in a sequence.
        //Outputs the following to Console 
        //  Unique values:
        //   2
        //   3
        //   5
        public static void MethodSyntaxExample() 
        { 
            int[] values = { 2, 2, 3, 5, 5 }; 

            var uniqueValues = values.Distinct(); 

            Console.WriteLine("Unique values:"); 
            foreach (var n in uniqueValues) 
            {
                Console.WriteLine(n); 
            }
        }
    }
}
