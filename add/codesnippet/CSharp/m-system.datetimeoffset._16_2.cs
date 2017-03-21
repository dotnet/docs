      DateTimeOffset outputDate = new DateTimeOffset(2007, 11, 1, 9, 0, 0, 
                                           new TimeSpan(-7, 0, 0)); 
      string format = "dddd, MMM dd yyyy HH:mm:ss zzz";
      
      // Output date and time using custom format specification
      Console.WriteLine(outputDate.ToString(format, null as DateTimeFormatInfo));
      Console.WriteLine(outputDate.ToString(format, CultureInfo.InvariantCulture));
      Console.WriteLine(outputDate.ToString(format, 
                                            new CultureInfo("fr-FR")));
      Console.WriteLine(outputDate.ToString(format, 
                                            new CultureInfo("es-ES")));
      // The example displays the following output to the console:
      //    Thursday, Nov 01 2007 09:00:00 -07:00
      //    Thursday, Nov 01 2007 09:00:00 -07:00
      //    jeudi, nov. 01 2007 09:00:00 -07:00
      //    jueves, nov 01 2007 09:00:00 -07:00