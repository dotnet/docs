      DateTimeOffset thisDate = new DateTimeOffset(2007, 6, 1, 6, 15, 0, 
                                                   DateTimeOffset.Now.Offset);
      string weekdayName = thisDate.ToString("dddd", 
                                             new CultureInfo("fr-fr")); 
      Console.WriteLine(weekdayName);                  // Displays vendredi     