// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\S+?)\b";
      string input = "This sentence is rather short but pointless.";

      MatchCollection matches = Regex.Matches(input, pattern);
      object[] words = new object[matches.Count * 2];
      
      int index = 0;
      foreach (Match match in matches)
      {
         match.Groups.CopyTo(words, index);
         index += 2;
      }
      
      // Display captured groups.
      for (int ctr = 1; ctr <= words.GetUpperBound(0); ctr += 2)
         Console.WriteLine(words[ctr]);
   }
}
// The example displays the following output:
//       This
//       sentence
//       is
//       rather
//       short
//       but
//       pointless
// </Snippet1>
