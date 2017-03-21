      Dim timeUtc As Date = Date.UtcNow
      Try
         Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
         Dim cstTime As Date = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone)
         Console.WriteLine("The date and time are {0} {1}.", _
                           cstTime, _
                           IIf(cstZone.IsDaylightSavingTime(cstTime), _
                               cstZone.DaylightName, cstZone.StandardName))
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The registry does not define the Central Standard Time zone.")
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.")
      End Try