// <Snippet5>
using System;
using System.Globalization;

public class Example5
{
   public static void Main()
   {
      CultureInfo culture = CultureInfo.CurrentCulture;
      Console.WriteLine($"The current culture is {culture.NativeName} [{culture.Name}]");
   }
}
// The example displays output like the following:
//       The current culture is English (United States) [en-US]
// </Snippet5>
