// <Snippet11>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "aaa(bbb)*ccc";
      string input = "aaaccc";
      Match match = Regex.Match(input, pattern);
      Console.WriteLine($"Match value: {match.Value}");
      if (match.Groups[1].Success)
         Console.WriteLine($"Group 1 value: {match.Groups[1].Value}");
      else
         Console.WriteLine("The first capturing group has no match.");
   }
}
// The example displays the following output:
//       Match value: aaaccc
//       The first capturing group has no match.
// </Snippet11>
