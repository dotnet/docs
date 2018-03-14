// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime dateValue = new DateTime(2009, 6, 1, 4, 37, 0);
      CultureInfo[] cultures = { new CultureInfo("en-US"), 
                                 new CultureInfo("fr-FR"),
                                 new CultureInfo("it-IT"),
                                 new CultureInfo("de-DE") };
      foreach (CultureInfo culture in cultures)
         Console.WriteLine("{0}: {1}", culture.Name, dateValue.ToString(culture));
   }
}
// The example displays the following output:
//       en-US: 6/1/2009 4:37:00 PM
//       fr-FR: 01/06/2009 16:37:00
//       it-IT: 01/06/2009 16.37.00
//       de-DE: 01.06.2009 16:37:00
// </Snippet3>
