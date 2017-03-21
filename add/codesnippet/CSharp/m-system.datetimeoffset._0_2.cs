      DateTimeOffset firstTime = new DateTimeOffset(2007, 11, 15, 11, 35, 00, 
                                          DateTimeOffset.Now.Offset);
      DateTimeOffset secondTime = firstTime;
      Console.WriteLine("{0} = {1}: {2}", 
                        firstTime, secondTime, 
                        DateTimeOffset.Equals(firstTime, secondTime));

      // The value of firstTime remains unchanged
      secondTime = new DateTimeOffset(firstTime.DateTime, 
                   TimeSpan.FromHours(firstTime.Offset.Hours + 1));      
      Console.WriteLine("{0} = {1}: {2}", 
                        firstTime, secondTime, 
                        DateTimeOffset.Equals(firstTime, secondTime));
                              
      // value of firstTime remains unchanged
      secondTime = new DateTimeOffset(firstTime.DateTime + TimeSpan.FromHours(1), 
                                      TimeSpan.FromHours(firstTime.Offset.Hours + 1));
      Console.WriteLine("{0} = {1}: {2}", 
                        firstTime, secondTime, 
                        DateTimeOffset.Equals(firstTime, secondTime));
       // The example produces the following output:
       //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -07:00: True
       //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -06:00: False
       //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 12:35:00 PM -06:00: True       