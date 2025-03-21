// <Snippet7>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "ABC123DEF456";
      string pattern = @"\d+";
      string substitution = "$_";
      Console.WriteLine($"Original string:          {input}");
      Console.WriteLine("String with substitution: {0}",
                        Regex.Replace(input, pattern, substitution));
   }
}
// The example displays the following output:
//       Original string:          ABC123DEF456
//       String with substitution: ABCABC123DEF456DEFABC123DEF456
// </Snippet7>
