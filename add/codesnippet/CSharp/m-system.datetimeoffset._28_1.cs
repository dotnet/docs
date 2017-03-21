      DateTime localTime = new DateTime(2007, 07, 12, 06, 32, 00); 
      DateTimeOffset dateAndOffset = new DateTimeOffset(localTime, 
                               TimeZoneInfo.Local.GetUtcOffset(localTime));
      Console.WriteLine(dateAndOffset);
      // The code produces the following output:
      //    7/12/2007 6:32:00 AM -07:00