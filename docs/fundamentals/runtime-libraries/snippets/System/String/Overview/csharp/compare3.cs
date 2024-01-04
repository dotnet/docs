// <Snippet13>
using System;

public class Example
{
   public static void Main()
   {
      // Search for "oe" and "œu" in "œufs" and "oeufs".
      string s1 = "œufs";
      string s2 = "oeufs";
      FindInString(s1, "oe", StringComparison.CurrentCulture);
      FindInString(s1, "oe", StringComparison.Ordinal);
      FindInString(s2, "œu", StringComparison.CurrentCulture);
      FindInString(s2, "œu", StringComparison.Ordinal);
      Console.WriteLine();
      
      string s3 = "co\u00ADoperative";
      FindInString(s3, "\u00AD", StringComparison.CurrentCulture);
      FindInString(s3, "\u00AD", StringComparison.Ordinal);
   }

   private static void FindInString(string s, string substring, StringComparison options)
   {
      int result = s.IndexOf(substring, options);
      if (result != -1)
         Console.WriteLine("'{0}' found in {1} at position {2}", 
                           substring, s, result);
      else
         Console.WriteLine("'{0}' not found in {1}", 
                           substring, s);                                                  
   }
}
// The example displays the following output:
//       'oe' found in œufs at position 0
//       'oe' not found in œufs
//       'œu' found in oeufs at position 0
//       'œu' not found in oeufs
//       
//       '­' found in co­operative at position 0
//       '­' found in co­operative at position 2
// </Snippet13>
