      DateTimeOffset offsetTime = new DateTimeOffset(2007, 11, 25, 11, 14, 00, 
                                  new TimeSpan(3, 0, 0));
      Console.WriteLine("{0} is equivalent to {1} {2}", 
                        offsetTime.ToString(), 
                        offsetTime.UtcDateTime.ToString(), 
                        offsetTime.UtcDateTime.Kind.ToString());      
      // The example displays the following output:
      //       11/25/2007 11:14:00 AM +03:00 is equivalent to 11/25/2007 8:14:00 AM Utc      