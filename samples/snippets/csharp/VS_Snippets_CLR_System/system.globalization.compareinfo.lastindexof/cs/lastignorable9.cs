// <Snippet10>
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
      
      // Use culture-sensitive comparison for the following searches:
      Console.WriteLine("Culture-sensitive comparisons:");
      // Find the index of the soft hyphen.
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00AD", position, CompareOptions.None));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00AD", position, CompareOptions.None));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn", position, CompareOptions.IgnoreCase));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn", position, CompareOptions.IgnoreCase));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm", position, CompareOptions.IgnoreCase));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm", position, CompareOptions.IgnoreCase));

      Console.WriteLine();         
      // Use ordinal comparison for the following searches:
      Console.WriteLine("Ordinal comparisons:");
      // Find the index of the soft hyphen.
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00AD", position, CompareOptions.Ordinal));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00AD", position, CompareOptions.Ordinal));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn", position, CompareOptions.Ordinal));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn", position, CompareOptions.Ordinal));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm", position, CompareOptions.Ordinal));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm", position, CompareOptions.Ordinal));
   }
}
// The example displays the following output:
//       Culture-sensitive comparisons:
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
//       
//       Ordinal comparisons:
//       'm' at position 4
//       3
//       'm' at position 3
//       -1
//       'm' at position 4
//       -1
//       'm' at position 3
//       -1
//       'm' at position 4
//       3
//       'm' at position 3
//       -1
// </Snippet10>

