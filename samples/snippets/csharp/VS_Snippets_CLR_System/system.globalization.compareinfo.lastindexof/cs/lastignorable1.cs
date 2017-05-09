// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
      
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // Find the index of the last soft hyphen.
      Console.WriteLine(ci.LastIndexOf(s1, "\u00AD"));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00AD"));
      
      // Find the index of the last soft hyphen followed by "n".
      Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn"));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn"));
      
      // Find the index of the last soft hyphen followed by "m".
      Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm"));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm"));
   }
}
// The example displays the following output:
//       6
//       5
//       1
//       1
//       4
//       3
// </Snippet2>

