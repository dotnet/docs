// <Snippet16>
using System;
using System.Globalization;
using System.IO;
using System.Threading;

public class Example1
{
   public static void Main1()
   {
      // Display the currency value.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      Decimal value = 16039.47m;
      Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
      Console.WriteLine("Currency Value: {0:C2}", value);

      // Persist the currency value as a string.
      StreamWriter sw = new StreamWriter("currency.dat");
      sw.Write(value.ToString("C2"));
      sw.Close();

      // Read the persisted data using the current culture.
      StreamReader sr = new StreamReader("currency.dat");
      string currencyData = sr.ReadToEnd();
      sr.Close();

      // Restore and display the data using the conventions of the current culture.
      Decimal restoredValue;
      if (Decimal.TryParse(currencyData, out restoredValue))
         Console.WriteLine(restoredValue.ToString("C2"));
      else
         Console.WriteLine("ERROR: Unable to parse '{0}'", currencyData);
      Console.WriteLine();

      // Restore and display the data using the conventions of the en-GB culture.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
      Console.WriteLine("Current Culture: {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      if (Decimal.TryParse(currencyData, NumberStyles.Currency, null, out restoredValue))
         Console.WriteLine(restoredValue.ToString("C2"));
      else
         Console.WriteLine("ERROR: Unable to parse '{0}'", currencyData);
      Console.WriteLine();
   }
}
// The example displays output like the following:
//       Current Culture: English (United States)
//       Currency Value: $16,039.47
//       ERROR: Unable to parse '$16,039.47'
//
//       Current Culture: English (United Kingdom)
//       ERROR: Unable to parse '$16,039.47'
// </Snippet16>
