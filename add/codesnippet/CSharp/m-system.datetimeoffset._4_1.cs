      DateTime localNow = DateTime.Now;
      DateTimeOffset localOffset = new DateTimeOffset(localNow);
      Console.WriteLine(localOffset.ToString());
      
      DateTime utcNow = DateTime.UtcNow;
      DateTimeOffset utcOffset = new DateTimeOffset(utcNow);
      Console.WriteLine(utcOffset.ToString());
      
      DateTime unspecifiedNow = DateTime.SpecifyKind(DateTime.Now, 
                                     DateTimeKind.Unspecified);
      DateTimeOffset unspecifiedOffset = new DateTimeOffset(unspecifiedNow);
      Console.WriteLine(unspecifiedOffset.ToString());
      //
      // The code produces the following output if run on Feb. 23, 2007, on
      // a system 8 hours earlier than UTC:
      //   2/23/2007 4:21:58 PM -08:00
      //   2/24/2007 12:21:58 AM +00:00
      //   2/23/2007 4:21:58 PM -08:00      