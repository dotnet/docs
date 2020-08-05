// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern, input;

      pattern = @"(a\1|(?(1)\1)){0,2}";
      input = "aaabbb";

      Console.WriteLine("Regex pattern: {0}", pattern);
      Match match = Regex.Match(input, pattern);
      Console.WriteLine("Match: '{0}' at position {1}.",
                        match.Value, match.Index);
      if (match.Groups.Count > 1) {
         for (int groupCtr = 1; groupCtr <= match.Groups.Count - 1; groupCtr++)
         {
            Group group = match.Groups[groupCtr];
            Console.WriteLine("   Group: {0}: '{1}' at position {2}.",
                              groupCtr, group.Value, group.Index);
            int captureCtr = 0;
            foreach (Capture capture in group.Captures) {
               captureCtr++;
               Console.WriteLine("      Capture: {0}: '{1}' at position {2}.",
                                 captureCtr, capture.Value, capture.Index);
            }
         }
      }
      Console.WriteLine();

      pattern = @"(a\1|(?(1)\1)){2}";
      Console.WriteLine("Regex pattern: {0}", pattern);
      match = Regex.Match(input, pattern);
         Console.WriteLine("Matched '{0}' at position {1}.",
                           match.Value, match.Index);
      if (match.Groups.Count > 1) {
         for (int groupCtr = 1; groupCtr <= match.Groups.Count - 1; groupCtr++)
         {
            Group group = match.Groups[groupCtr];
            Console.WriteLine("   Group: {0}: '{1}' at position {2}.",
                              groupCtr, group.Value, group.Index);
            int captureCtr = 0;
            foreach (Capture capture in group.Captures) {
               captureCtr++;
               Console.WriteLine("      Capture: {0}: '{1}' at position {2}.",
                                 captureCtr, capture.Value, capture.Index);
            }
         }
      }
   }
}
// The example displays the following output:
//       Regex pattern: (a\1|(?(1)\1)){0,2}
//       Match: '' at position 0.
//          Group: 1: '' at position 0.
//             Capture: 1: '' at position 0.
//
//       Regex pattern: (a\1|(?(1)\1)){2}
//       Matched 'a' at position 0.
//          Group: 1: 'a' at position 0.
//             Capture: 1: '' at position 0.
//             Capture: 2: 'a' at position 0.
// </Snippet2>
