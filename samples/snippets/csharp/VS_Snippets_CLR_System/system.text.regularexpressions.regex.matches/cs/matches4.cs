// <Snippet4>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\w+es\b";
      string sentence = "NOTES: Any notes or comments are optional.";
      
      // Call Matches method without specifying any options.
      foreach (Match match in Regex.Matches(sentence, pattern))
         Console.WriteLine("Found '{0}' at position {1}", 
                           match.Value, match.Index);
      Console.WriteLine();

      // Call Matches method for case-insensitive matching.
      foreach (Match match in Regex.Matches(sentence, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine("Found '{0}' at position {1}", 
                           match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found 'notes' at position 11
//       
//       Found 'NOTES' at position 0
//       Found 'notes' at position 11
// </Snippet4>
