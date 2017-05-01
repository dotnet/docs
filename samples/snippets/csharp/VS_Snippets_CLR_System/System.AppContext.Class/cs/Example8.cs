// <Snippet8>
using System;
using System.Reflection;

[assembly: AssemblyVersion("2.0.0.0")]

public static class StringLibrary
{
   public static int SubstringStartsAt(String fullString, String substr)
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
         String value = "The archaeologist";
         String substring = "archæ";
         int position = StringLibrary.SubstringStartsAt(value, substring); 
         if (position >= 0) 
            Console.WriteLine("'{0}' found in '{1}' starting at position {2}",
                           substring, value, position);
         else
            Console.WriteLine("'{0}' not found in '{1}'", substring, value);
      }
   }
   // The example displays the following output:
   //       'archæ' found in 'The archaeologist' starting at position 4   
   // </Snippet9>
}


