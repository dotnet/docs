using System;
using System.Linq;

namespace Ordering
{
    public class ThenByDescendingComparer1
    {
        //This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first by 
        // word length and then by a case-insensitive descending sort of the words in an array.
        //Outputs to the console:
        // aPPLE
        //  ClOvEr
        //  cHeRry
        //  bRaNcH
        //  AbAcUs
        //  BlUeBeRrY
        public static void MethodSyntaxExample()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }; 

            var sortedWords = 
                words.OrderBy(a => a.Length)
                     .ThenByDescending(a => a, new CaseInsensitiveComparer()); //See CaseInsensitiveComparer.cs

            foreach (var w in sortedWords) 
            {
                Console.WriteLine(w); 
            }
        }
    }
}
