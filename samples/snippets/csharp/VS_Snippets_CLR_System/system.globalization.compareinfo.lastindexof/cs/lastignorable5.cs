// <Snippet6>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
      
      string s1 = "ani\u00ADmal";
      string s2 = "animal";
      
      Console.WriteLine("Culture-sensitive comparison:");
      // Use culture-sensitive comparison to find the last soft hyphen.
      Console.WriteLine(ci.LastIndexOf(s1, "\u00AD", CompareOptions.None));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00AD", CompareOptions.None));
      
      // Use culture-sensitive comparison to find the last soft hyphen followed by "n".
      Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn", CompareOptions.None));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn", CompareOptions.None));
      
      // Use culture-sensitive comparison to find the last soft hyphen followed by "m".
      Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm", CompareOptions.None));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm", CompareOptions.None));
      
      Console.WriteLine("Ordinal comparison:");
      // Use ordinal comparison to find the last soft hyphen.
      Console.WriteLine(ci.LastIndexOf(s1, "\u00AD", CompareOptions.Ordinal));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00AD", CompareOptions.Ordinal));
      
      // Use ordinal comparison to find the last soft hyphen followed by "n".
      Console.WriteLine(ci.LastIndexOf(s1, "\u00ADn", CompareOptions.Ordinal));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00ADn", CompareOptions.Ordinal));
      
      // Use ordinal comparison to find the last soft hyphen followed by "m".
      Console.WriteLine(ci.LastIndexOf(s1, "\u00ADm", CompareOptions.Ordinal));
      Console.WriteLine(ci.LastIndexOf(s2, "\u00ADm", CompareOptions.Ordinal));
   }
}
// The example displays the following output:
//       6
//       5
//       1
//       1
//       4
//       3
//       Ordinal comparison:
//       3
//       -1
//       -1
//       -1
//       3
//       -1
// </Snippet6>

