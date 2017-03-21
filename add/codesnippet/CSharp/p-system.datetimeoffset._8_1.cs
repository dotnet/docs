      DateTimeOffset localTime = DateTimeOffset.Now;
      DateTimeOffset utcTime = DateTimeOffset.UtcNow;
      
      Console.WriteLine("Local Time:          {0}", localTime.ToString("T"));
      Console.WriteLine("Difference from UTC: {0}", localTime.Offset.ToString());
      Console.WriteLine("UTC:                 {0}", utcTime.ToString("T"));
      // If run on a particular date at 1:19 PM, the example produces
      // the following output:
      //    Local Time:          1:19:43 PM
      //    Difference from UTC: -07:00:00
      //    UTC:                 8:19:43 PM      