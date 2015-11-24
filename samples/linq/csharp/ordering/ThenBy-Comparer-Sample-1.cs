using System;
using System.Linq;

namespace Ordering
{
    public class ThenByComparer1
    {
        //This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort 
        // first by word length and then by a case-insensitive sort of the words in an array.
        //Outputs to the console:
        //  aPPLE
        //  AbAcUs
        //  bRaNcH
        //  cHeRry
        //  ClOvEr
        //  BlUeBeRrY
        public static void MethodSyntaxExample()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }; 

            var sortedWords = words.OrderBy(a => a.Length)
                                   .ThenBy(a => a, new CaseInsensitiveComparer()); 

            foreach (var w in sortedWords) 
            {
                Console.WriteLine(w); 
            }
        }
    }
}
