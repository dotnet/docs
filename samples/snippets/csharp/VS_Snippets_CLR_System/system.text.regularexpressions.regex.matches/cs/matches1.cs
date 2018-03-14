// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\w+es\b";
      Regex rgx = new Regex(pattern);
      string sentence = "Who writes these notes?";
      
      foreach (Match match in rgx.Matches(sentence))
         Console.WriteLine("Found '{0}' at position {1}", 
                           match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found 'writes' at position 4
//       Found 'notes' at position 17
// </Snippet1>
