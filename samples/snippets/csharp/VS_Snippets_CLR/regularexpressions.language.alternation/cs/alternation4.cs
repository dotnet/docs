// <Snippet4>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b";
      string input = "01-9999999 020-333333 777-88-9999";
      Console.WriteLine($"Matches for {pattern}:");
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine($"   {match.Value} at position {match.Index}");
   }
}
// The example displays the following output:
//       Matches for \b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b:
//          01-9999999 at position 0
//          777-88-9999 at position 22
// </Snippet4>
