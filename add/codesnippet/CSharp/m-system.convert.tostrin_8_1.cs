      // Define an array of numbers to display.
      decimal[] numbers = { 1734231911290.16m, -17394.32921m,
                            3193.23m, 98012368321.684m };
      // Define the culture names used to display them.
      string[] cultureNames = { "en-US", "fr-FR", "ja-JP", "ru-RU" };
      
      foreach (decimal number in numbers)
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
      //    1734231911290.16:
      //       en-US:     1734231911290.16
      //       fr-FR:     1734231911290,16
      //       ja-JP:     1734231911290.16
      //       ru-RU:     1734231911290,16
      //    
      //    -17394.32921:
      //       en-US:         -17394.32921
      //       fr-FR:         -17394,32921
      //       ja-JP:         -17394.32921
      //       ru-RU:         -17394,32921
      //    
      //    3193.23:
      //       en-US:              3193.23
      //       fr-FR:              3193,23
      //       ja-JP:              3193.23
      //       ru-RU:              3193,23
      //    
      //    98012368321.684:
      //       en-US:      98012368321.684
      //       fr-FR:      98012368321,684
      //       ja-JP:      98012368321.684
      //       ru-RU:      98012368321,684