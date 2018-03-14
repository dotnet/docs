
// <Snippet8>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo culture;
      DateTimeFormatInfo dtfi;
      
      culture = CultureInfo.CurrentCulture;
      dtfi = culture.DateTimeFormat;
      Console.WriteLine("Culture Name:      {0}", culture.Name);
      Console.WriteLine("User Overrides:    {0}", culture.UseUserOverride);
      Console.WriteLine("Long Time Pattern: {0}\n", culture.DateTimeFormat.LongTimePattern);
            
      culture = new CultureInfo(CultureInfo.CurrentCulture.Name, false);
      Console.WriteLine("Culture Name:      {0}",   culture.Name);
      Console.WriteLine("User Overrides:    {0}",   culture.UseUserOverride);
      Console.WriteLine("Long Time Pattern: {0}\n", culture.DateTimeFormat.LongTimePattern);
   }
}
// The example displays the following output:
//       Culture Name:      en-US
//       User Overrides:    True
//       Long Time Pattern: HH:mm:ss
//       
//       Culture Name:      en-US
//       User Overrides:    False
//       Long Time Pattern: h:mm:ss tt
// </Snippet8>
