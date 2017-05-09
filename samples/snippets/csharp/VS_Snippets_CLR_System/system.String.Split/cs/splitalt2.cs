// <Snippet9>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      String input = "[This is captured\ntext.]\n\n[\n" +
                     "[This is more captured text.]\n]\n" +
                     "[Some more captured text:\n   Option1" +
                     "\n   Option2][Terse text.]";
      String pattern = @"\[([^\[\]]+)\]";
      int ctr = 0;
      foreach (Match m in Regex.Matches(input, pattern))
         Console.WriteLine("{0}: {1}", ++ctr, m.Groups[1].Value);
   }
}
// The example displays the following output:
//       1: This is captured
//       text.
//       2: This is more captured text.
//       3: Some more captured text:
//          Option1
//          Option2
//       4: Terse text.
// </Snippet9>

