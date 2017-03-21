      System.Globalization.CultureInfo ci = null;
      System.Globalization.DateTimeFormatInfo dtfi = null;
      
      // Instantiate a culture using CreateSpecificCulture.
      ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
      dtfi = ci.DateTimeFormat;
      Console.WriteLine("{0} from CreateSpecificCulture: {1}", ci.Name, dtfi.IsReadOnly);
      
      // Instantiate a culture using the CultureInfo constructor.
      ci = new System.Globalization.CultureInfo("en-CA"); 
      dtfi = ci.DateTimeFormat;
      Console.WriteLine("{0} from CultureInfo constructor: {1}", ci.Name, dtfi.IsReadOnly);
      
      // Retrieve a culture by calling the GetCultureInfo method.
      ci = System.Globalization.CultureInfo.GetCultureInfo("en-AU");
      dtfi = ci.DateTimeFormat;
      Console.WriteLine("{0} from GetCultureInfo: {1}", ci.Name, dtfi.IsReadOnly);
      
      // Instantiate a DateTimeFormatInfo object by calling DateTimeFormatInfo.GetInstance.  
      ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
      dtfi = System.Globalization.DateTimeFormatInfo.GetInstance(ci);
      Console.WriteLine("{0} from GetInstance: {1}", ci.Name, dtfi.IsReadOnly);
      
      // The example displays the following output:
      //      en-US from CreateSpecificCulture: False
      //      en-CA from CultureInfo constructor: False
      //      en-AU from GetCultureInfo: True
      //      en-GB from GetInstance: False