      short[] numbers = {-23092, 0, 14894, Int16.MaxValue};
      CultureInfo[] providers = {new CultureInfo("en-us"), 
                                 new CultureInfo("fr-fr"), 
                                 new CultureInfo("de-de"), 
                                 new CultureInfo("es-es")};
      foreach (Int16 int16Value in numbers)
      {
         foreach (CultureInfo provider in providers)
         {
            Console.Write("{0, 6} ({1})     ", 
                          int16Value.ToString(provider), 
                          provider.Name);
         }
         Console.WriteLine();
      }
      // The example displays the following output to the console:
      //       -23092 (en-US)     -23092 (fr-FR)     -23092 (de-DE)     -23092 (es-ES)
      //            0 (en-US)          0 (fr-FR)          0 (de-DE)          0 (es-ES)
      //        14894 (en-US)      14894 (fr-FR)      14894 (de-DE)      14894 (es-ES)
      //        32767 (en-US)      32767 (fr-FR)      32767 (de-DE)      32767 (es-ES)      