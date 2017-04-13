// <Snippet4>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b.*[.?!;:](\s|\z)";
      string input = "this. what: is? go, thing.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       this. what: is? go, thing.
// </Snippet4>
