      DateTimeOffset instanceTime = new DateTimeOffset(2007, 10, 31, 0, 0, 0, 
                                    DateTimeOffset.Now.Offset);
      
      DateTimeOffset otherTime = instanceTime;
      Console.WriteLine("{0} = {1}: {2}", 
                        instanceTime, otherTime, 
                        instanceTime.EqualsExact(otherTime));
                        
      otherTime = new DateTimeOffset(instanceTime.DateTime, 
                  TimeSpan.FromHours(instanceTime.Offset.Hours + 1));
      Console.WriteLine("{0} = {1}: {2}", 
                        instanceTime, otherTime, 
                        instanceTime.EqualsExact(otherTime));
                        
      otherTime = new DateTimeOffset(instanceTime.DateTime + TimeSpan.FromHours(1), 
                      TimeSpan.FromHours(instanceTime.Offset.Hours + 1));
      Console.WriteLine("{0} = {1}: {2}", 
                        instanceTime, otherTime,
                        instanceTime.EqualsExact(otherTime));
      // The example produces the following output:
      //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -07:00: True
      //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -06:00: False
      //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 1:00:00 AM -06:00: False       