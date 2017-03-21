      DateTime dateWithoutOffset = new DateTime(2007, 7, 16, 13, 32, 00);
      DateTimeOffset timeFromTicks = new DateTimeOffset(dateWithoutOffset.Ticks, 
                                     new TimeSpan(-5, 0, 0));
      Console.WriteLine(timeFromTicks.ToString());
      // The code produces the following output:
      //    7/16/2007 1:32:00 PM -05:00