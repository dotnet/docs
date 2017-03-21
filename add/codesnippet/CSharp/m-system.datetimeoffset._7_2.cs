      CultureInfo[] cultures = new CultureInfo[] {CultureInfo.InvariantCulture, 
                                                 new CultureInfo("en-us"), 
                                                 new CultureInfo("fr-fr"), 
                                                 new CultureInfo("de-DE"), 
                                                 new CultureInfo("es-ES")};

      DateTimeOffset thisDate = new DateTimeOffset(2007, 5, 1, 9, 0, 0, 
                                                   TimeSpan.Zero);                                            
 
      foreach (CultureInfo culture in cultures)
      {
         string cultureName; 
         if (string.IsNullOrEmpty(culture.Name))
            cultureName = culture.NativeName;
         else
            cultureName = culture.Name;

         Console.WriteLine("In {0}, {1}", 
                           cultureName, thisDate.ToString(culture));
      }                                            
      // The example produces the following output:
      //    In Invariant Language (Invariant Country), 05/01/2007 09:00:00 +00:00
      //    In en-US, 5/1/2007 9:00:00 AM +00:00
      //    In fr-FR, 01/05/2007 09:00:00 +00:00
      //    In de-DE, 01.05.2007 09:00:00 +00:00
      //    In es-ES, 01/05/2007 9:00:00 +00:00