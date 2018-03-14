// <Snippet13>
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
      
      // All the following comparisons are culture-sensitive.
      Console.WriteLine("Culture-sensitive comparisons:"); 
      // Find the index of the soft hyphen.
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00AD", position, 
                           position + 1, CompareOptions.None));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00AD", position, 
                           position + 1, CompareOptions.None));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn", position, 
                           position + 1, CompareOptions.IgnoreCase));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn", position, 
                           position + 1, CompareOptions.IgnoreCase));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm", position, 
                           position + 1, CompareOptions.IgnoreCase));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm", position, 
                           position + 1, CompareOptions.IgnoreCase));

      // All the following comparisons are ordinal.
      Console.WriteLine("\nOrdinal comparisons:"); 
      // Find the index of the soft hyphen.
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00AD", position, 
                           position + 1, CompareOptions.Ordinal));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00AD", position, 
                           position + 1, CompareOptions.Ordinal));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn", position, 
                           position + 1, CompareOptions.Ordinal));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn", position, 
                           position + 1, CompareOptions.Ordinal));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.LastIndexOf(s1, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm", position, 
                           position + 1, CompareOptions.Ordinal));

      position = ci.LastIndexOf(s2, "m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm", position, 
                           position + 1, CompareOptions.Ordinal));
   }
}
// The example displays the following output:
//       Culture-sensitive comparisons:
//       'm' at position 1
//       4
//       'm' at position 1
//       3
//       'm' at position 1
//       1
//       'm' at position 1
//       1
//       'm' at position 1
//       4
//       'm' at position 1
//       3
//
//       Ordinal comparisons:
//       'm' at position 1
//       3
//       'm' at position 1
//       -1
//       'm' at position 1
//       -1
//       'm' at position 1
//       -1
//       'm' at position 1
//       3
//       'm' at position 1
//       -1
// </Snippet13>

