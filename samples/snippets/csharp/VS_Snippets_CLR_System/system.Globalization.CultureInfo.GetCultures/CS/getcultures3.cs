// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
       CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture |
                                                        CultureTypes.SpecificCultures);
      int ctr = 0;
      foreach (var culture in cultures)
         if ((culture.CultureTypes & CultureTypes.UserCustomCulture) == CultureTypes.UserCustomCulture)
            ctr++;

      Console.WriteLine("Number of Specific Custom Cultures: {0}", ctr);
   }
}
// If run under Windows 8, the example displays output like the following:
//      Number of Specific Custom Cultures: 6
// If run under Windows 10, the example displays output like the following:
//      Number of Specific Custom Cultures: 279
// </Snippet2>


