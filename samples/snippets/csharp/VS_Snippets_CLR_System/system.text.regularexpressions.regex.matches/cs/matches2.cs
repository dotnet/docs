// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\w+es\b";
      string sentence = "Who writes these notes?";
      
      foreach (Match match in Regex.Matches(sentence, pattern))
         Console.WriteLine("Found '{0}' at position {1}", 
                           match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found 'writes' at position 4
//       Found 'notes' at position 17
// </Snippet2>
