// <Snippet11>
using System;

public class Example
{
   public static void Main()
   {
      int position = 0;

      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // Find the index of the soft hyphen.
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00AD", position, position + 1));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00AD", position, position + 1));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADn", position, position + 1));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADn", position, position + 1));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.LastIndexOf("\u00ADm", position, position + 1));

      position = s2.LastIndexOf("m");
      Console.WriteLine("'m' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.LastIndexOf("\u00ADm", position, position + 1));
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

