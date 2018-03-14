// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "--(.+?)--";
      string replacement = "($1)";
      string input = "He said--decisively--that the time--whatever time it was--had come.";
      foreach (Match match in Regex.Matches(input, pattern))
      {
         string result = match.Result(replacement);
         Console.WriteLine(result);
      }
   }
}
// The example displays the following output:
//       (decisively)
//       (whatever time it was)
// </Snippet1>
