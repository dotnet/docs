// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b[at]\w+";
      string text = "The threaded application ate up the thread pool as it executed.";
      MatchCollection matches;

      Regex defaultRegex = new Regex(pattern);
      // Get matches of pattern in text
      matches = defaultRegex.Matches(text);
      Console.WriteLine("Parsing '{0}'", text);
      // Iterate matches
      for (int ctr = 0; ctr < matches.Count; ctr++)
         Console.WriteLine("{0}. {1}", ctr, matches[ctr].Value);
   }
}
// The example displays the following output:
//       Parsing 'The threaded application ate up the thread pool as it executed.'
//       0. threaded
//       1. application
//       2. ate
//       3. the
//       4. thread
//       5. as
// </Snippet1>
