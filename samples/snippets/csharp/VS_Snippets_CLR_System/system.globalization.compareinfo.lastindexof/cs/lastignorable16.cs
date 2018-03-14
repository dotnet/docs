// <Snippet17>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;

      string searchString = "\u00ADm";
      string s1 = "ani\u00ADmal" ;
      string s2 = "animal";
      int position;

      position = ci.LastIndexOf(s1, 'm');
      if (position >= 0) {
         Console.WriteLine(ci.LastIndexOf(s1, searchString, position, 3, CompareOptions.None));
         Console.WriteLine(ci.LastIndexOf(s1, searchString, position, 3, CompareOptions.Ordinal));
      }
      
      position = ci.LastIndexOf(s2, 'm');
      if (position >= 0) {
         Console.WriteLine(ci.LastIndexOf(s2, searchString, position, 3, CompareOptions.None));
         Console.WriteLine(ci.LastIndexOf(s2, searchString, position, 3, CompareOptions.Ordinal));
      }
   }
}
// The example displays the following output:
//       4
//       3
//       3
//       -1
// </Snippet17>
