// <Snippet1>
using System;
using System.Globalization;
using System.Resources;

public class Example
{
   public static void Main()
   {
      String[] numbers = { "one", "two", "three", "four", "five", "six",
                           "seven", "eight", "nine", "ten" };
      var rm = new ResourceManager(typeof(NumberResources));
      ResourceSet rs = rm.GetResourceSet(CultureInfo.CreateSpecificCulture("fr-FR"),
                                         true, false);
      if (rs == null) {
         Console.WriteLine("No resource set.");
         return;
      }

      foreach (var number in numbers)
         Console.WriteLine("{0,-10} '{1}'", number + ":", rs.GetString(number));
   }
}

internal class NumberResources {}
// The example displays the following output:
//       one:       'un'
//       two:       'deux'
//       three:     'trois'
//       four:      'quatre'
//       five:      ''
//       six:       ''
//       seven:     ''
//       eight:     ''
//       nine:      ''
//       ten:       ''
// </Snippet1>