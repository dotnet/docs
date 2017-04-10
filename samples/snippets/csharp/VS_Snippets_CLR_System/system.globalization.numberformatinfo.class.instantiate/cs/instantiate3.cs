
// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo culture;
      NumberFormatInfo nfi;
      
      culture = CultureInfo.CurrentCulture;
      nfi = culture.NumberFormat;
      Console.WriteLine("Culture Name:    {0}", culture.Name);
      Console.WriteLine("User Overrides:  {0}", culture.UseUserOverride);
      Console.WriteLine("Currency Symbol: {0}\n", culture.NumberFormat.CurrencySymbol);
            
      culture = new CultureInfo(CultureInfo.CurrentCulture.Name, false);
      Console.WriteLine("Culture Name:    {0}", culture.Name);
      Console.WriteLine("User Overrides:  {0}", culture.UseUserOverride);
      Console.WriteLine("Currency Symbol: {0}", culture.NumberFormat.CurrencySymbol);
   }
}
// The example displays the following output:
//       Culture Name:    en-US
//       User Overrides:  True
//       Currency Symbol: USD
//       
//       Culture Name:    en-US
//       User Overrides:  False
//       Currency Symbol: $
// </Snippet3>
