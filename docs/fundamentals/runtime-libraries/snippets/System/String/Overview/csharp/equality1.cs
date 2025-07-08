// <Snippet11>
using System;
using System.Globalization;
using System.Threading;

public class Example4
{
   public static void Main()
   {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR");      

      string filePath = "file://c:/notes.txt";
      
      Console.WriteLine("Culture-sensitive test for equality:");
      if (! TestForEquality(filePath, StringComparison.CurrentCultureIgnoreCase))
         Console.WriteLine($"Access to {filePath} is allowed.");
      else
         Console.WriteLine($"Access to {filePath} is not allowed.");
      
      Console.WriteLine("\nOrdinal test for equality:");
      if (! TestForEquality(filePath, StringComparison.OrdinalIgnoreCase))
         Console.WriteLine($"Access to {filePath} is allowed.");
      else
         Console.WriteLine($"Access to {filePath} is not allowed.");
   }

   private static bool TestForEquality(string str, StringComparison cmp)
   {
      int position = str.IndexOf("://");
      if (position < 0) return false;

      string substring = str.Substring(0, position);  
      return substring.Equals("FILE", cmp);
   }
}
// The example displays the following output:
//       Culture-sensitive test for equality:
//       Access to file://c:/notes.txt is allowed.
//       
//       Ordinal test for equality:
//       Access to file://c:/notes.txt is not allowed.
// </Snippet11>
