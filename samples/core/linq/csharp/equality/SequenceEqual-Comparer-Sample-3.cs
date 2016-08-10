using System;
using System.Linq;

namespace Equality
{
    //This sample uses SequenceEqual and with a custom comparer to do a 
    // case-insensitive comparison of the words in an array.
    //Outputs to the console: 
    // The sequences match: True
    public class SequenceEqualComparer1
    {
        public static void MethodSyntaxExample()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberrY" }; 
            var wordsB = new string[] { "cherry", "Apple", "Blueberry" };

            bool match = wordsA.SequenceEqual(wordsB, new CaseInsensitiveComparer()); //See CaseInsensitiveComparer.cs
          
            Console.WriteLine("The sequences match: {0}", match); 
        }
    }
}
