// <Snippet4>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\b(\w+)\W+)+";
      string input = "This is a short sentence.";
      Match match = Regex.Match(input, pattern);
      Console.WriteLine($"Match: '{match.Value}'");
      for (int ctr = 1; ctr < match.Groups.Count; ctr++)
      {
         Console.WriteLine($"   Group {ctr}: '{match.Groups[ctr].Value}'");
         int capCtr = 0;
         foreach (Capture capture in match.Groups[ctr].Captures)
         {
            Console.WriteLine($"      Capture {capCtr}: '{capture.Value}'");
            capCtr++;
         }
      }
   }
}
// The example displays the following output:
//       Match: 'This is a short sentence.'
//          Group 1: 'sentence.'
//             Capture 0: 'This '
//             Capture 1: 'is '
//             Capture 2: 'a '
//             Capture 3: 'short '
//             Capture 4: 'sentence.'
//          Group 2: 'sentence'
//             Capture 0: 'This'
//             Capture 1: 'is'
//             Capture 2: 'a'
//             Capture 3: 'short'
//             Capture 4: 'sentence'
// </Snippet4>
