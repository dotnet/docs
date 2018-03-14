// <Snippet11>
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
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00AD", position, position + 1));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00AD", position, position + 1));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn", position, position + 1));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn", position, position + 1));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm", position, position + 1));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm", position, position + 1));
   }
}
// The example displays the following output:
//       'm' at position 4
//       4
//       'm' at position 3
//       3
//       'm' at position 4
//       1
//       'm' at position 3
//       1
//       'm' at position 4
//       4
//       'm' at position 3
//       3
// </Snippet11>

