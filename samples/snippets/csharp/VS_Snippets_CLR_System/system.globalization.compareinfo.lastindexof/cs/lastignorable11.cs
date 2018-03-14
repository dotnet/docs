// <Snippet12>
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
      
      // Find the index of the soft hyphen using culture-sensitive comparison.
      position = ci.LastIndexOf(s1, 'm');
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, '\u00AD', position, 
                           position + 1, CompareOptions.IgnoreCase));
      
      position = ci.LastIndexOf(s2, 'm');
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s2, '\u00AD', position, 
                           position + 1, CompareOptions.IgnoreCase));
         
      // Find the index of the soft hyphen using ordinal comparison.
      position = ci.LastIndexOf(s1, 'm');
      Console.WriteLine("'m' at position {0}", position, CompareOptions.Ordinal);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, '\u00AD', position, 
                           position + 1, CompareOptions.Ordinal));
      
      position = ci.LastIndexOf(s2, 'm');
      Console.WriteLine("'m' at position {0}", position, CompareOptions.Ordinal);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s2, '\u00AD', position, 
                           position + 1, CompareOptions.Ordinal));
   }
}
// The example displays the following output:
//       'm' at position 4
//       4
//       'm' at position 3
//       3
//       'm' at position 4
//       3
//       'm' at position 3
//       -1
// </Snippet12>

