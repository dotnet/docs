// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
      
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      // Find the index of the soft hyphen using culture-sensitive comparison.
      Console.WriteLine(ci.IndexOf(s1, '\u00AD', CompareOptions.IgnoreCase));
      Console.WriteLine(ci.IndexOf(s2, '\u00AD', CompareOptions.IgnoreCase));

      // Find the index of the soft hyphen using ordinal comparison.
      Console.WriteLine(ci.IndexOf(s1, '\u00AD', CompareOptions.Ordinal));
      Console.WriteLine(ci.IndexOf(s2, '\u00AD', CompareOptions.Ordinal));
   }
}
// The example displays the following output:
//       0
//       0
//       3
//       -1
// </Snippet4>

