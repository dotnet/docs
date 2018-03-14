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
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00AD", position, s1.Length - position));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00AD", position, s2.Length - position));
      
      // Find the index of the soft hyphen followed by "n".
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00ADn", position, s1.Length - position));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00ADn", position, s2.Length - position));
      
      // Find the index of the soft hyphen followed by "m".
      position = s1.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)
         Console.WriteLine(s1.IndexOf("\u00ADm", position, s1.Length - position));

      position = s2.IndexOf("n");
      Console.WriteLine("'n' at position {0}", position);
      if (position >= 0)   
         Console.WriteLine(s2.IndexOf("\u00ADm", position, s2.Length - position));
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
// </Snippet11>

