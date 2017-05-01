// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "Yes. This dog is very friendly.";
      string pattern = @"((\w+)[\s.])+";
      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine("Match: {0}", match.Value);
         for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
         {
            Group group = match.Groups[groupCtr];
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value);
            for (int captureCtr = 0; captureCtr < group.Captures.Count; captureCtr++)
               Console.WriteLine("      Capture {0}: {1}", captureCtr, 
                                 group.Captures[captureCtr].Value);
         }                      
      }
   }
}
// The example displays the following output:
//       Match: Yes.
//          Group 0: Yes.
//             Capture 0: Yes.
//          Group 1: Yes.
//             Capture 0: Yes.
//          Group 2: Yes
//             Capture 0: Yes
//       Match: This dog is very friendly.
//          Group 0: This dog is very friendly.
//             Capture 0: This dog is very friendly.
//          Group 1: friendly.
//             Capture 0: This
//             Capture 1: dog
//             Capture 2: is
//             Capture 3: very
//             Capture 4: friendly.
//          Group 2: friendly
//             Capture 0: This
//             Capture 1: dog
//             Capture 2: is
//             Capture 3: very
//             Capture 4: friendly
// </Snippet1>      
