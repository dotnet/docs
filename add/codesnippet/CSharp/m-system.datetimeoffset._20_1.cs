      DateTime localTime = DateTime.Now;
      DateTimeOffset nonLocalDateWithOffset = new DateTimeOffset(localTime.Ticks, 
                                        new TimeSpan(2, 0, 0));
      Console.WriteLine(nonLocalDateWithOffset); 
      //
      // The code produces the following output if run on Feb. 23, 2007:
      //    2/23/2007 4:37:50 PM +02:00