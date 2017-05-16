// <Snippet1>
using System;

public static class StringExtensions
{
   public static bool Contains(this String str, String substring, 
                               StringComparison comp)
   {                            
      if (substring == null)
         throw new ArgumentNullException("substring", 
                                         "substring cannot be null.");
      else if (! Enum.IsDefined(typeof(StringComparison), comp))
         throw new ArgumentException("comp is not a member of StringComparison",
                                     "comp");

      return str.IndexOf(substring, comp) >= 0;                      
   }
}
// </Snippet1>

namespace App
{
// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      String s = "This is a string.";
      String sub1 = "this";
      Console.WriteLine("Does '{0}' contain '{1}'?", s, sub1);
      StringComparison comp = StringComparison.Ordinal;
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp));
      
      comp = StringComparison.OrdinalIgnoreCase;
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp));
   }
}
// The example displays the following output:
//       Does 'This is a string.' contain 'this'?
//          Ordinal: False
//          OrdinalIgnoreCase: True
// </Snippet2>
}



