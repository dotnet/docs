// <Snippet10>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      String input = "abacus -- alabaster - * - atrium -+- " +
                     "any -*- actual - + - armoir - - alarm";
      String pattern = @"\s-\s?[+*]?\s?-\s";
      String[] elements = Regex.Split(input, pattern);
      foreach (var element in elements)
         Console.WriteLine(element);
   }
}
// The example displays the following output:
//       abacus
//       alabaster
//       atrium
//       any
//       actual
//       armoir
//       alarm
// </Snippet10>
