      DateTimeOffset date1 = new DateTimeOffset(2008, 1, 1, 13, 32, 45, 
                             new TimeSpan(-5, 0, 0)); 
      TimeSpan interval1 = new TimeSpan(202, 3, 30, 0);
      TimeSpan interval2 = new TimeSpan(5, 0, 0, 0);      
      DateTimeOffset date2; 
      
      Console.WriteLine(date1);         // Displays 1/1/2008 1:32:45 PM -05:00
      date2 = date1 + interval1;
      Console.WriteLine(date2);         // Displays 7/21/2008 5:02:45 PM -05:00
      date2 += interval2;
      Console.WriteLine(date2);         // Displays 7/26/2008 5:02:45 PM -05:00     