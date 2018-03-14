// <Snippet3>
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
      Console.WriteLine(ci.LastIndexOf(s1, '\u00AD'));
      Console.WriteLine(ci.LastIndexOf(s2, '\u00AD'));
   }
}
// The example displays the following output:
//       6
//       5
// </Snippet3>

