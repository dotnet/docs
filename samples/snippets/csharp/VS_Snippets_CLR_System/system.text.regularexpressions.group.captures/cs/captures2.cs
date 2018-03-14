// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is a sentence. This is another sentence.";
      string pattern = @"\b(\w+\s*)+\.";
      Match match = Regex.Match(input, pattern);
      if (match.Success) {
         Console.WriteLine("Matched text: {0}", match.Value);
         for (int ctr = 1; ctr < match.Groups.Count; ctr++) {
            Console.WriteLine("   Group {0}:  {1}", ctr, match.Groups[ctr].Value);
            int captureCtr = 0;
            foreach (Capture capture in match.Groups[ctr].Captures) {
               Console.WriteLine("      Capture {0}: {1}", 
                                 captureCtr, capture.Value);
               captureCtr++; 
            }
         }
      }   
   }
}
// The example displays the following output:
//       Matched text: This is a sentence.
//          Group 1:  sentence
//             Capture 0: This
//             Capture 1: is
//             Capture 2: a
//             Capture 3: sentence
// </Snippet2>
