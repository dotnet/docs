      System.Globalization.CultureInfo specific, neutral;
      System.Globalization.DateTimeFormatInfo dtfi;
     
      // Instantiate a culture by creating a specific culture and using its Parent property.
      specific = System.Globalization.CultureInfo.GetCultureInfo("fr-FR");
      neutral = specific.Parent;
      dtfi = neutral.DateTimeFormat;
      Console.WriteLine("{0} from Parent property: {1}", neutral.Name, dtfi.IsReadOnly);
      
      dtfi = System.Globalization.CultureInfo.GetCultureInfo("fr-FR").Parent.DateTimeFormat;
      Console.WriteLine("{0} from Parent property: {1}", neutral.Name, dtfi.IsReadOnly);

      // Instantiate a neutral culture using the CultureInfo constructor.
      neutral = new System.Globalization.CultureInfo("fr");
      dtfi = neutral.DateTimeFormat;
      Console.WriteLine("{0} from CultureInfo constructor: {1}", neutral.Name, dtfi.IsReadOnly);
      
      // Instantiate a culture using CreateSpecificCulture. 
      neutral = System.Globalization.CultureInfo.CreateSpecificCulture("fr");
      dtfi = neutral.DateTimeFormat;
      Console.WriteLine("{0} from CreateSpecificCulture: {1}", neutral.Name, dtfi.IsReadOnly);
      
      // Retrieve a culture by calling the GetCultureInfo method.
      neutral = System.Globalization.CultureInfo.GetCultureInfo("fr");
      dtfi = neutral.DateTimeFormat;
      Console.WriteLine("{0} from GetCultureInfo: {1}", neutral.Name, dtfi.IsReadOnly);

      // Instantiate a DateTimeFormatInfo object by calling GetInstance.  
      neutral = System.Globalization.CultureInfo.CreateSpecificCulture("fr");
      dtfi = System.Globalization.DateTimeFormatInfo.GetInstance(neutral);
      Console.WriteLine("{0} from GetInstance: {1}", neutral.Name, dtfi.IsReadOnly);

      // The example displays the following output:
      //       fr from Parent property: False
      //       fr from Parent property: False
      //       fr from CultureInfo constructor: False
      //       fr-FR from CreateSpecificCulture: False
      //       fr from GetCultureInfo: True
      //       fr-FR from GetInstance: False      