// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\bthe\w*\b";
      string input = "The man then told them about that event.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine($"Found {match.Value} at index {match.Index}.");

      Console.WriteLine();
      foreach (Match match in Regex.Matches(input, pattern,
                                            RegexOptions.IgnoreCase))
         Console.WriteLine($"Found {match.Value} at index {match.Index}.");
   }
}
// The example displays the following output:
//       Found then at index 8.
//       Found them at index 18.
//
//       Found The at index 0.
//       Found then at index 8.
//       Found them at index 18.
// </Snippet1>
