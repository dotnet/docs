// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // Find the index of the last soft hyphen.
      Console.WriteLine(s1.LastIndexOf("\u00AD"));
      Console.WriteLine(s2.LastIndexOf("\u00AD"));
      
      // Find the index of the last soft hyphen followed by "n".
      Console.WriteLine(s1.LastIndexOf("\u00ADn"));
      Console.WriteLine(s2.LastIndexOf("\u00ADn"));
      
      // Find the index of the last soft hyphen followed by "m".
      Console.WriteLine(s1.LastIndexOf("\u00ADm"));
      Console.WriteLine(s2.LastIndexOf("\u00ADm"));
   }
}
// The example displays the following output:
//       6
//       5
//       1
//       1
//       4
//       3
// </Snippet3>

