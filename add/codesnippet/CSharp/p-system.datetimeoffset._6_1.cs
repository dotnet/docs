      DateTimeOffset offsetDate; 
      DateTime regularDate;
      
      offsetDate = DateTimeOffset.Now;
      regularDate = offsetDate.DateTime;
      Console.WriteLine("{0} converts to {1}, Kind {2}.", 
                        offsetDate.ToString(), 
                        regularDate,  
                        regularDate.Kind);
                     
      offsetDate = DateTimeOffset.UtcNow;
      regularDate = offsetDate.DateTime;
      Console.WriteLine("{0} converts to {1}, Kind {2}.", 
                        offsetDate.ToString(), 
                        regularDate, 
                        regularDate.Kind);
      // If run on 3/6/2007 at 17:11, produces the following output:
      //
      //   3/6/2007 5:11:22 PM -08:00 converts to 3/6/2007 5:11:22 PM, Kind Unspecified.
      //   3/7/2007 1:11:22 AM +00:00 converts to 3/7/2007 1:11:22 AM, Kind Unspecified.                        