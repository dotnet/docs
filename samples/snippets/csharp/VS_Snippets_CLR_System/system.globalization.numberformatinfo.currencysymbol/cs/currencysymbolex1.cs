// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      Decimal value = 106.25m;
      Console.WriteLine("Current Culture: {0}",
                        CultureInfo.CurrentCulture.Name);
      Console.WriteLine("Currency Symbol: {0}",
                        NumberFormatInfo.CurrentInfo.CurrencySymbol);
      Console.WriteLine("Currency Value:  {0:C2}", value);
   }
}
// The example displays the following output:
//       Current Culture: en-US
//       Currency Symbol: $
//       Currency Value:  $106.25
// </Snippet1>