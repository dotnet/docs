// <Snippet7>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "abc";
      string input = "abc123abc456abc789";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("{0} found at position {1}.", 
                           match.Value, match.Index);
   }
}
// The example displays the following output:
//       abc found at position 0.
//       abc found at position 6.
//       abc found at position 12.
// </Snippet7>
