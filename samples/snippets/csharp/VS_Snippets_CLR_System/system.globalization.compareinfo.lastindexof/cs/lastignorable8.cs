// <Snippet9>
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
      
      // Find the index of the soft hyphen.
      position = ci.IndexOf(s1, 'm');
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, '\u00AD', position, position + 1));
      
      position = ci.IndexOf(s2, 'm');
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s2, '\u00AD', position, position + 1));
   }
}
// The example displays the following output:
//       'm' at position 4
//       4
//       'm' at position 3
//       3
// </Snippet9>

