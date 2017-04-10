// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b[at]\w+";
      RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;
      string text = "The threaded application ate up the thread pool as it executed.";
      MatchCollection matches;

      Regex optionRegex = new Regex(pattern, options);
      Console.WriteLine("Parsing '{0}' with options {1}:", text, options.ToString());
      // Get matches of pattern in text
      matches = optionRegex.Matches(text);
      // Iterate matches
      for (int ctr = 0; ctr < matches.Count; ctr++)
         Console.WriteLine("{0}. {1}", ctr, matches[ctr].Value);
   }
}
// The example displays the following output:
//    Parsing 'The threaded application ate up the thread pool as it executed.'
//        with options IgnoreCase, Compiled:
//    0. The
//    1. threaded
//    2. application
//    3. ate
//    4. the
//    5. thread
//    6. as
// </Snippet2>
