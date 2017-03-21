      string fmt = "dd MMM yyyy HH:mm:ss";
      DateTime thisDate = new DateTime(2007, 06, 12, 19, 00, 14, 16);
      DateTimeOffset offsetDate = new DateTimeOffset(thisDate.Year, 
                                                     thisDate.Month, 
                                                     thisDate.Day, 
                                                     thisDate.Hour,
                                                     thisDate.Minute,
                                                     thisDate.Second,
                                                     thisDate.Millisecond, 
                                                     new TimeSpan(2, 0, 0));  
      Console.WriteLine("Current time: {0}:{1}", offsetDate.ToString(fmt), offsetDate.Millisecond);
      // The code produces the following output:
      //    Current time: 12 Jun 2007 19:00:14:16      