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
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00AD", position, 
                           s1.Length - position, CompareOptions.None));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00AD", position, 
                           s2.Length - position, CompareOptions.None));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00ADn", position, 
                           s1.Length - position, CompareOptions.IgnoreCase));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00ADn", position, 
                           s2.Length - position, CompareOptions.IgnoreCase));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00ADm", position, 
                           s1.Length - position, CompareOptions.IgnoreCase));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00ADm", position, 
                           s2.Length - position, CompareOptions.IgnoreCase));

      // All the following comparisons are ordinal.
      Console.WriteLine("\nOrdinal comparisons:"); 
      // Find the index of the soft hyphen.
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00AD", position, 
                           s1.Length - position, CompareOptions.Ordinal));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00AD", position, 
                           s2.Length - position, CompareOptions.Ordinal));
      
      // Find the index of the soft hyphen followed by "n".
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00ADn", position, 
                           s1.Length - position, CompareOptions.Ordinal));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00ADn", position, 
                           s2.Length - position, CompareOptions.Ordinal));
      
      // Find the index of the soft hyphen followed by "m".
      position = ci.IndexOf(s1, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(ci.IndexOf(s1, "\u00ADm", position, 
                           s1.Length - position, CompareOptions.Ordinal));

      position = ci.IndexOf(s2, "n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(ci.IndexOf(s2, "\u00ADm", position, 
                           s2.Length - position, CompareOptions.Ordinal));
   }
}
// The example displays the following output:
//       Culture-sensitive comparisons:
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
//
//       Ordinal comparisons:
//       'n' at position 1
//       3
//       'n' at position 1
//       -1
//       'n' at position 1
//       -1
//       'n' at position 1
//       -1
//       'n' at position 1
//       3
//       'n' at position 1
//       -1
// </Snippet13>

