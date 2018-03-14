// <Snippet7>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
      
      int position = 0;

      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // Find the index of the soft hyphen.
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00AD", position));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00AD", position));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00ADn", position));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00ADn", position));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00ADm", position));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00ADm", position));
   }
}
// The example displays the following output:
//       'n' at position 1
//       1
//       'n' at position 1
//       1
//       'n' at position 1
//       1
//       'n' at position 1
//       1
//       'n' at position 1
//       4
//       'n' at position 1
//       3
// </Snippet7>

