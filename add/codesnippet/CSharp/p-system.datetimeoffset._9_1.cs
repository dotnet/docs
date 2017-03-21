      DateTimeOffset localTime = DateTimeOffset.Now;
      Console.WriteLine("The local time zone is {0} hours and {1} minutes {2} than UTC.", 
                        Math.Abs(localTime.Offset.Hours), 
                        localTime.Offset.Minutes, 
                        localTime.Offset.Hours < 0 ? "earlier" : "later");
      // The example displays output similar to the following for a system in the
      // U.S. Pacific Standard Time zone: 
      //       The local time zone is 8 hours and 0 minutes earlier than UTC.      