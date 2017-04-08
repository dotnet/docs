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
      position = ci.IndexOf(s1, 'n');
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, '\u00AD', position, s1.Length - position));
      
      position = ci.IndexOf(s2, 'n');
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s2, '\u00AD', position, s2.Length - position));
   }
}
// The example displays the following output:
//       'n' at position 1
//       1
//       'n' at position 1
//       1
// </Snippet9>

