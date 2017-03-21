   Private Sub DisplayDateWithTimeZoneName(date1 As Date, timeZone As TimeZoneInfo)
      Console.WriteLine("The time is {0:t} on {0:d} {1}", _
                        date1, _
                        IIf(timeZone.IsDaylightSavingTime(date1), _
                            timezone.DaylightName, timezone.StandardName))   
   End Sub
   ' The example displays output similar to the following:
   '    The time is 1:00 AM on 4/2/2006 Pacific Standard Time   