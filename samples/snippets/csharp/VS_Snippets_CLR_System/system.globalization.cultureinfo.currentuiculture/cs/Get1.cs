// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo culture = CultureInfo.CurrentUICulture;
      Console.WriteLine("The current UI culture is {0} [{1}]",
                        culture.NativeName, culture.Name);
   }
}
// The example displays output like the following:
//       The current UI culture is English (United States) [en-US]
// </Snippet5>

