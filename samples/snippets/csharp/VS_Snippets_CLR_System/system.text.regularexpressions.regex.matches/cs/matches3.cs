// <Snippet3>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\w+es\b";
      Regex rgx = new Regex(pattern);
      string sentence = "Who writes these notes and uses our paper?";
      
      // Get the first match.
      Match match = rgx.Match(sentence);
      if (match.Success) {
         Console.WriteLine("Found first 'es' in '{0}' at position {1}", 
                           match.Value, match.Index);
         // Get any additional matches.
         foreach (Match m in rgx.Matches(sentence, match.Index + match.Length))
            Console.WriteLine("Also found '{0}' at position {1}", 
                              m.Value, m.Index);
      }   
   }
}
// The example displays the following output:
//       Found first 'es' in 'writes' at position 4
//       Also found 'notes' at position 17
//       Also found 'uses' at position 27
// </Snippet3>
