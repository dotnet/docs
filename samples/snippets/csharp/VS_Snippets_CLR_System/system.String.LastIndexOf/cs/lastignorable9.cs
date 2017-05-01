// <Snippet10>
using System;

public class Example
{
   public static void Main()
   {
      int position = 0;

      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // Use culture-sensitive comparison for the following searches:
      Console.WriteLine("Culture-sensitive comparisons:");
      // Find the index of the soft hyphen.
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00AD", position, StringComparison.CurrentCulture));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00AD", position, StringComparison.CurrentCulture));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADn", position, StringComparison.CurrentCultureIgnoreCase));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADn", position, StringComparison.CurrentCultureIgnoreCase));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADm", position, StringComparison.CurrentCultureIgnoreCase));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADm", position, StringComparison.CurrentCultureIgnoreCase));

      Console.WriteLine();         
      // Use ordinal comparison for the following searches:
      Console.WriteLine("Ordinal comparisons:");
      // Find the index of the soft hyphen.
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00AD", position, StringComparison.Ordinal));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00AD", position, StringComparison.Ordinal));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADn", position, StringComparison.Ordinal));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADn", position, StringComparison.Ordinal));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADm", position, StringComparison.Ordinal));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADm", position, StringComparison.Ordinal));
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

