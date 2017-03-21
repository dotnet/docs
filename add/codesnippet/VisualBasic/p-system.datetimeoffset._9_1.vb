      Dim localTime As DateTimeOffset = DateTimeOffset.Now
      Console.WriteLine("The local time zone is {0} hours and {1} minutes {2} than UTC.", _
                        Math.Abs(localTime.Offset.Hours), _
                        localTime.Offset.Minutes, _
                        IIf(localTime.Offset.Hours < 0, "earlier", "later"))
      ' If run on a system whose local time zone is U.S. Pacific Standard Time,
      ' the example displays output similar to the following:
      '       The local time zone is 8 hours and 0 minutes earlier than UTC.      