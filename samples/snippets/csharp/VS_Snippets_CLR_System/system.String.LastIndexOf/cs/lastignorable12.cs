// <Snippet13>
using System;

public class Example
{
   public static void Main()
   {
      int position = 0;

      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // All the following comparisons are culture-sensitive.
      Console.WriteLine("Culture-sensitive comparisons:"); 
      // Find the index of the soft hyphen.
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00AD", position, 
                           position + 1, StringComparison.CurrentCulture));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00AD", position, 
                           position + 1, StringComparison.CurrentCulture));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADn", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADn", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADm", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADm", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase));

      // All the following comparisons are ordinal.
      Console.WriteLine("\nOrdinal comparisons:"); 
      // Find the index of the soft hyphen.
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00AD", position, 
                           position + 1, StringComparison.Ordinal));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00AD", position, 
                           position + 1, StringComparison.Ordinal));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADn", position, 
                           position + 1, StringComparison.Ordinal));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADn", position, 
                           position + 1, StringComparison.Ordinal));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADm", position, 
                           position + 1, StringComparison.Ordinal));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADm", position, 
                           position + 1, StringComparison.Ordinal));
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

