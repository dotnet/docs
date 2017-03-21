         DateTime specificDate = new DateTime(2008, 5, 1, 06, 32, 00); 
         DateTimeOffset offsetDate = new DateTimeOffset(specificDate.Year, 
                                         specificDate.Month, 
                                         specificDate.Day, 
                                         specificDate.Hour, 
                                         specificDate.Minute, 
                                         specificDate.Second, 
                                         new TimeSpan(-5, 0, 0));
         Console.WriteLine("Current time: {0}", offsetDate);
         Console.WriteLine("Corresponding UTC time: {0}", offsetDate.UtcDateTime);                                              
      // The code produces the following output:
      //    Current time: 5/1/2008 6:32:00 AM -05:00
      //    Corresponding UTC time: 5/1/2008 11:32:00 AM      