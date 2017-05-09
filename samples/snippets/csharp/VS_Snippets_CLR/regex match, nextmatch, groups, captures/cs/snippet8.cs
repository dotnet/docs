//<snippet8>
using System;
using System.Text.RegularExpressions;

class Example 
{
   static void Main() 
   {
      string text = "One car red car blue car";
      string pat = @"(\w+)\s+(car)";

      // Instantiate the regular expression object.
      Regex r = new Regex(pat, RegexOptions.IgnoreCase);
      
      // Match the regular expression pattern against a text string.
      Match m = r.Match(text);
      int matchCount = 0;
      while (m.Success) 
      {
         Console.WriteLine("Match"+ (++matchCount));
         for (int i = 1; i <= 2; i++) 
         {
            Group g = m.Groups[i];
            Console.WriteLine("Group"+i+"='" + g + "'");
            CaptureCollection cc = g.Captures;
            for (int j = 0; j < cc.Count; j++) 
            {
               Capture c = cc[j];
               System.Console.WriteLine("Capture"+j+"='" + c + "', Position="+c.Index);
            }
         }
         m = m.NextMatch();
      }
   }
}
// This example displays the following output:
//       Match1
//       Group1='One'
//       Capture0='One', Position=0
//       Group2='car'
//       Capture0='car', Position=4
//       Match2
//       Group1='red'
//       Capture0='red', Position=8
//       Group2='car'
//       Capture0='car', Position=12
//       Match3
//       Group1='blue'
//       Capture0='blue', Position=16
//       Group2='car'
//       Capture0='car', Position=21
//</snippet8>

