      DateTimeOffset firstDate = new DateTimeOffset(2008, 3, 25, 18, 0, 0, 
                                                    new TimeSpan(-7, 0, 0));
      DateTimeOffset secondDate = new DateTimeOffset(2008, 3, 25, 18, 0, 0, 
                                                     new TimeSpan(-5, 0, 0));
      DateTimeOffset thirdDate = new DateTimeOffset(2008, 2, 28, 9, 0, 0, 
                                                    new TimeSpan(-7, 0, 0));
      TimeSpan difference;
      
      difference = firstDate.Subtract(secondDate);
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", 
                        firstDate.ToString(), 
                        secondDate.ToString(), 
                        difference.Days, 
                        difference.Hours, 
                        difference.Minutes);      
      
      difference = firstDate.Subtract(thirdDate);
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", 
                        firstDate.ToString(), 
                        secondDate.ToString(), 
                        difference.Days, 
                        difference.Hours, 
                        difference.Minutes); 
      // The example produces the following output:
      //    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 0 days, 2:00
      //    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 26 days, 9:00                                 