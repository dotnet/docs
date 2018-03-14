// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      // Create a custom culture for ru-US.
      CultureAndRegionInfoBuilder car1 = new CultureAndRegionInfoBuilder("ru-US", 
                                             CultureAndRegionModifiers.None);
      car1.LoadDataFromCultureInfo(CultureInfo.CreateSpecificCulture("ru-RU"));
      car1.LoadDataFromRegionInfo(new RegionInfo("en-US"));
      
      car1.CultureEnglishName = "Russian (United States)";
      car1.CultureNativeName = "русский (США)";
      car1.CurrencyNativeName = "Доллар (США)";
      car1.RegionNativeName = "США";

      // Register the culture.
      try {
         car1.Register();
      }    
      catch (InvalidOperationException) {
         // Swallow the exception: the culture already is registered.
      }
      
      // Use the custom culture.
      CultureInfo ci = CultureInfo.CreateSpecificCulture("ru-US");
      Thread.CurrentThread.CurrentCulture = ci;
      Console.WriteLine("Current Culture: {0}", 
                        Thread.CurrentThread.CurrentCulture.Name);
      Console.WriteLine("Writing System: {0}", 
                        Thread.CurrentThread.CurrentCulture.TextInfo);
   }
}
// The example displays the following output:
//     Current Culture: ru-US
//     Writing System: TextInfo - ru-US
// </Snippet1>