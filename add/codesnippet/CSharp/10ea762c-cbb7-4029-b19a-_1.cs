      CultureInfo fmt;
      int year; 
      Calendar cal;
      DateTimeOffset dateInCal;
      
      // Instantiate DateTimeOffset with Hebrew calendar
      year = 5770;
      cal = new HebrewCalendar();
      fmt = new CultureInfo("he-IL");
      fmt.DateTimeFormat.Calendar = cal;      
      dateInCal = new DateTimeOffset(year, 7, 12, 
                                     15, 30, 0, 0, 
                                     cal, 
                                     new TimeSpan(2, 0, 0));
      // Display the date in the Hebrew calendar
      Console.WriteLine("Date in Hebrew Calendar: {0:g}", 
                         dateInCal.ToString(fmt));
      // Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal);
      Console.WriteLine();

      // Instantiate DateTimeOffset with Hijri calendar
      year = 1431;
      cal = new HijriCalendar();
      fmt = new CultureInfo("ar-SA");
      fmt.DateTimeFormat.Calendar = cal;
      dateInCal = new DateTimeOffset(year, 7, 12, 
                                     15, 30, 0, 0, 
                                     cal, 
                                     new TimeSpan(2, 0, 0));
      // Display the date in the Hijri calendar
      Console.WriteLine("Date in Hijri Calendar: {0:g}", 
                         dateInCal.ToString(fmt));
      // Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal);
      Console.WriteLine();