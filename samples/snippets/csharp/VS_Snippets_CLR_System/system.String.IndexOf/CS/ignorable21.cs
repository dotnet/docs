// <Snippet21>
using System;

public class Example
{
   public static void Main()
   {
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // Find the index of the soft hyphen.
      Console.WriteLine(s1.IndexOf("\u00AD"));
      Console.WriteLine(s2.IndexOf("\u00AD"));
      
      // Find the index of the soft hyphen followed by "n".
      Console.WriteLine(s1.IndexOf("\u00ADn"));
      Console.WriteLine(s2.IndexOf("\u00ADn"));
      
      // Find the index of the soft hyphen followed by "m".
      Console.WriteLine(s1.IndexOf("\u00ADm"));
      Console.WriteLine(s2.IndexOf("\u00ADm"));
   }
}
// The example displays the following output
// if run under the .NET Framework 4 or later:
//       0
//       0
//       1
//       1
//       4
//       3
// </Snippet21>

