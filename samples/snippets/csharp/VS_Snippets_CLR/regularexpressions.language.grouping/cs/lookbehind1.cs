// <Snippet9>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "2010 1999 1861 2140 2009";
      string pattern = @"(?<=\b20)\d{2}\b";
      
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       10
//       09
// </Snippet9>
