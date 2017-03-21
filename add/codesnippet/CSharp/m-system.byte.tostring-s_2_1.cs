      byte byteValue = 250;
      CultureInfo[] providers = {new CultureInfo("en-us"), 
                                 new CultureInfo("fr-fr"), 
                                 new CultureInfo("es-es"), 
                                 new CultureInfo("de-de")}; 
      
      foreach (CultureInfo provider in providers) 
         Console.WriteLine("{0} ({1})", 
                           byteValue.ToString("N2", provider), provider.Name);
      // The example displays the following output to the console:
      //       250.00 (en-US)
      //       250,00 (fr-FR)
      //       250,00 (es-ES)
      //       250,00 (de-DE)      