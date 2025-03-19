// <Snippet8>
using System;
using System.Reflection;

[assembly: AssemblyVersion("2.0.0.0")]

public static class StringLibrary
{
   public static int SubstringStartsAt(string fullString, string substr)
   {
      bool flag;
      if (AppContext.TryGetSwitch("StringLibrary.DoNotUseCultureSensitiveComparison", out flag) && flag == true)
         return fullString.IndexOf(substr, StringComparison.Ordinal);
      else
         return fullString.IndexOf(substr, StringComparison.CurrentCulture);
   }
}
// </Snippet8>

namespace App
{
   // <Snippet9>
   using System;

   public class Example
   {
      public static void Main()
      {
         string value = "The archaeologist";
         string substring = "archæ";
         int position = StringLibrary.SubstringStartsAt(value, substring);
         if (position >= 0)
            Console.WriteLine($"'{substring}' found in '{value}' starting at position {position}");
         else
            Console.WriteLine($"'{substring}' not found in '{value}'");
      }
   }
   // The example displays the following output:
   //       'archæ' found in 'The archaeologist' starting at position 4
   // </Snippet9>
}
