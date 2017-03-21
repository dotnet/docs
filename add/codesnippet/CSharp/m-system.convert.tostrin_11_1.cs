      // Specify the date to be formatted using various cultures.
      DateTime tDate = new DateTime(2010, 4, 15, 20, 30, 40, 333);
      // Specify the cultures.
      string[] cultureNames = { "en-US", "es-AR", "fr-FR", "hi-IN",
                                "ja-JP", "nl-NL", "ru-RU", "ur-PK" };
      
      Console.WriteLine("Converting the date {0}: ", 
                        Convert.ToString(tDate, 
                                System.Globalization.CultureInfo.InvariantCulture));

      foreach (string cultureName in cultureNames)
      {
         System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
         string dateString = Convert.ToString(tDate, culture);
         Console.WriteLine("   {0}:  {1,-12}", 
                           culture.Name, dateString);
      }             
      // The example displays the following output:
      //       Converting the date 04/15/2010 20:30:40:
      //          en-US:  4/15/2010 8:30:40 PM
      //          es-AR:  15/04/2010 08:30:40 p.m.
      //          fr-FR:  15/04/2010 20:30:40
      //          hi-IN:  15-04-2010 20:30:40
      //          ja-JP:  2010/04/15 20:30:40
      //          nl-NL:  15-4-2010 20:30:40
      //          ru-RU:  15.04.2010 20:30:40
      //          ur-PK:  15/04/2010 8:30:40 PM      