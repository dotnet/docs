      byte[] numbers = { 12, 100, Byte.MaxValue };
      // Define the culture names used to display them.
      string[] cultureNames = { "en-US", "fr-FR" };
      
      foreach (byte number in numbers)
      {
         Console.WriteLine("{0}:", Convert.ToString(number,
                                   System.Globalization.CultureInfo.InvariantCulture));
         foreach (string cultureName in cultureNames)
         {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
            Console.WriteLine("   {0}: {1,20}",
                              culture.Name, Convert.ToString(number, culture));
         }
         Console.WriteLine();
      }   
      // The example displays the following output:
      //       12:
      //          en-US:                   12
      //          fr-FR:                   12
      //       
      //       100:
      //          en-US:                  100
      //          fr-FR:                  100
      //       
      //       255:
      //          en-US:                  255
      //          fr-FR:                  255      