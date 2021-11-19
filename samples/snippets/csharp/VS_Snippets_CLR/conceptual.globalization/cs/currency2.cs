// <Snippet17>
using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

public class Example2
{
   public static void Main2()
   {
      // Display the currency value.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      Decimal value = 16039.47m;
      Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
      Console.WriteLine("Currency Value: {0:C2}", value);

      // Serialize the currency data.
      BinaryFormatter bf = new BinaryFormatter();
      FileStream fw = new FileStream("currency.dat", FileMode.Create);
      CurrencyValue data = new CurrencyValue(value, CultureInfo.CurrentCulture.Name);
      bf.Serialize(fw, data);
      fw.Close();
      Console.WriteLine();

      // Change the current culture.
      CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
      Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName);

      // Deserialize the data.
      FileStream fr = new FileStream("currency.dat", FileMode.Open);
      CurrencyValue restoredData = (CurrencyValue) bf.Deserialize(fr);
      fr.Close();

      // Display the original value.
      CultureInfo culture = CultureInfo.CreateSpecificCulture(restoredData.CultureName);
      Console.WriteLine("Currency Value: {0}", restoredData.Amount.ToString("C2", culture));
   }
}

[Serializable] internal struct CurrencyValue
{
   public CurrencyValue(Decimal amount, string name)
   {
      this.Amount = amount;
      this.CultureName = name;
   }

   public Decimal Amount;
   public string CultureName;
}
// The example displays the following output:
//       Current Culture: English (United States)
//       Currency Value: $16,039.47
//
//       Current Culture: English (United Kingdom)
//       Currency Value: $16,039.47
// </Snippet17>
