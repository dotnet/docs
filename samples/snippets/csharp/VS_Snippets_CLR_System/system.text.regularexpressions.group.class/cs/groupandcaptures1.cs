// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\b(\w+?)[,:;]?\s?)+[?.!]";
      string input = "This is one sentence. This is a second sentence.";

      Match match = Regex.Match(input, pattern);
      Console.WriteLine("Match: " + match.Value);
      int groupCtr = 0;
      foreach (Group group in match.Groups)
      {
         groupCtr++;
         Console.WriteLine("   Group {0}: '{1}'", groupCtr, group.Value);
         int captureCtr = 0;
         foreach (Capture capture in group.Captures)
         {
            captureCtr++;
            Console.WriteLine("      Capture {0}: '{1}'", captureCtr, capture.Value);
         }
      }   
   }
}
// The example displays the following output:
//       Match: This is one sentence.
//          Group 1: 'This is one sentence.'
//             Capture 1: 'This is one sentence.'
//          Group 2: 'sentence'
//             Capture 1: 'This '
//             Capture 2: 'is '
//             Capture 3: 'one '
//             Capture 4: 'sentence'
//          Group 3: 'sentence'
//             Capture 1: 'This'
//             Capture 2: 'is'
//             Capture 3: 'one'
//             Capture 4: 'sentence'
// </Snippet1>
