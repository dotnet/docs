// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\w+)\b";
      string input = "This is one sentence.";
      Match match = Regex.Match(input, pattern);
      if (match.Success) {
         Console.WriteLine("Matched text: {0}", match.Value);
         for (int ctr = 1; ctr <= match.Groups.Count - 1; ctr++) {
            Console.WriteLine("   Group {0}:  {1}", ctr, match.Groups[ctr].Value);
            int captureCtr = 0;
            foreach (Capture capture in match.Groups[ctr].Captures) {
               Console.WriteLine("      Capture {0}: {1}", 
                                 captureCtr, capture.Value);
               captureCtr += 1;                  
            }
         }
      }   
   }
}
// The example displays the following output:
//       Matched text: This
//          Group 1:  This
//             Capture 0: This
// </Snippet1>      
