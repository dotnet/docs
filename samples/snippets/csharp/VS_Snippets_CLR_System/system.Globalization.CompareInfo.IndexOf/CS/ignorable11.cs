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
      position = ci.IndexOf(s1, 'n');
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, '\u00AD', position, 
                           s1.Length - position, CompareOptions.IgnoreCase));
      
      position = ci.IndexOf(s2, 'n');
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s2, '\u00AD', position, 
                           s2.Length - position, CompareOptions.IgnoreCase));
         
      // Find the index of the soft hyphen using ordinal comparison.
      position = ci.IndexOf(s1, 'n');
      Console.WriteLine("'n' at position {0}", position, CompareOptions.Ordinal);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, '\u00AD', position, 
                           s1.Length - position, CompareOptions.Ordinal));
      
      position = ci.IndexOf(s2, 'n');
      Console.WriteLine("'n' at position {0}", position, CompareOptions.Ordinal);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s2, '\u00AD', position, 
                           s2.Length - position, CompareOptions.Ordinal));
   }
}
// The example displays the following output:
//       'n' at position 1
//       1
//       'n' at position 1
//       1
//       'n' at position 1
//       3
//       'n' at position 1
//       -1
// </Snippet12>

