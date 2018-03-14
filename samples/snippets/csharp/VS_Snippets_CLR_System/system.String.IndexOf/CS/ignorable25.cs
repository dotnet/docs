// <Snippet25>
using System;

public class Example
{
   public static void Main()
   {
      string searchString = "\u00ADm";
      string s1 = "ani\u00ADmal" ;
      string s2 = "animal";

      Console.WriteLine(s1.IndexOf(searchString, 2, StringComparison.CurrentCulture));
      Console.WriteLine(s1.IndexOf(searchString, 2, StringComparison.Ordinal));
      Console.WriteLine(s2.IndexOf(searchString, 2, StringComparison.CurrentCulture));
      Console.WriteLine(s2.IndexOf(searchString, 2, StringComparison.Ordinal));
   }
}
// The example displays the following output:
//       4
//       3
//       3
//       -1
// </Snippet25>
