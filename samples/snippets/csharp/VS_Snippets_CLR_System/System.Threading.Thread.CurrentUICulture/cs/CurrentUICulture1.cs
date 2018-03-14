// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      // Change the current culture if the language is not French.
      CultureInfo current = Thread.CurrentThread.CurrentUICulture;
      if (current.TwoLetterISOLanguageName != "fr") {
         CultureInfo newCulture = CultureInfo.CreateSpecificCulture("en-US");
         Thread.CurrentThread.CurrentUICulture = newCulture;
         // Make current UI culture consistent with current culture.
         Thread.CurrentThread.CurrentCulture = newCulture;
      }
      Console.WriteLine("The current UI culture is {0} [{1}]",
                        Thread.CurrentThread.CurrentUICulture.NativeName,
                        Thread.CurrentThread.CurrentUICulture.Name);
      Console.WriteLine("The current culture is {0} [{1}]",
                        Thread.CurrentThread.CurrentUICulture.NativeName,
                        Thread.CurrentThread.CurrentUICulture.Name);
   }
}
// The example displays the following output:
//     The current UI culture is English (United States) [en-US]
//     The current culture is English (United States) [en-US]
// </Snippet1>

