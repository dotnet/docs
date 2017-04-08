// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
      
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      int position = 0;
      
      // Find the last index of the soft hyphen.
      position = ci.LastIndexOf(s1, 'm');
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, '\u00AD', position));
      
      position = ci.LastIndexOf(s2, 'm');
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s2, '\u00AD', position));
   }
}
// The example displays the following output:
//       'm' at position 4
//       4
//       'm' at position 3
// </Snippet5>

