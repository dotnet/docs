using System;
using System.Linq;

namespace Ordering
{
    public class OrderByComparer1
    {
        //This sample uses an OrderBy clause with a custom comparer to do a case-insensitive sort of the words in an array.
        //Outputs to the console:
        //  AbAcUs
        //  aPPLE
        //  BlUeBeRrY
        //  bRaNcH
        //  cHeRry
        //  ClOvEr
        public static void MethodSyntaxExample()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }; 
  
            var sortedWords = words.OrderBy(a => a, new CaseInsensitiveComparer()); //See CaseInsensitiveComparer.cs
            
            foreach (var w in sortedWords) 
            { 
                Console.WriteLine(w); 
            } 
        }      
    }
}
