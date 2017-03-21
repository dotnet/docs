      DateTimeOffset date1 = new DateTimeOffset(2007, 6, 3, 14, 45, 0, 
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date2 = new DateTimeOffset(2007, 6, 3, 15, 45, 0,
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date3 = new DateTimeOffset(date1.DateTime, 
                   new TimeSpan(-6, 0, 0));
      DateTimeOffset date4 = date1;
      Console.WriteLine(date1 >= date2);        // Displays False
      Console.WriteLine(date1 >= date3);        // Displays True 
      Console.WriteLine(date1 >= date4);        // Displays True 