using System;
using System.Linq;

namespace Equality
{
    //This sample uses SequenceEqual to see if two sequences match on all elements in the same order.
    //Outputs to the console: 
    // The sequences match: True
    public class SequenceEqual1
    {
        public static void MethodSyntaxExample()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" }; 
            var wordsB = new string[] { "cherry", "apple", "blueberry" }; 
        
            bool match = wordsA.SequenceEqual(wordsB); 
        
            Console.WriteLine("The sequences match: {0}", match); 
        }
    }
}
