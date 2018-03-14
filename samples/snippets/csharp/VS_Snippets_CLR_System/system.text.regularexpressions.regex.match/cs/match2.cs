// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\ba\w*\b";
      string input = "An extraordinary day dawns with each new day.";
      Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
      if (m.Success)
         Console.WriteLine("Found '{0}' at position {1}.", m.Value, m.Index);
   }
}
// The example displays the following output:
//        Found 'An' at position 0.
// </Snippet2>