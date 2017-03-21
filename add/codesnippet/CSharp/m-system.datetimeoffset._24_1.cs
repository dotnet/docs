      DateTimeOffset offsetDate = new DateTimeOffset(2007, 12, 3, 11, 30, 0, 
                                     new TimeSpan(-8, 0, 0)); 
      TimeSpan duration = new TimeSpan(7, 18, 0, 0);
      Console.WriteLine(offsetDate.Subtract(duration).ToString());  // Displays 11/25/2007 5:30:00 PM -08:00