      Dim hwTime As Date = #2/01/2007 8:00:00 AM#
      Try
         Dim hwZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time")
         Console.WriteLine("{0} {1} is {2} local time.", _
                           hwTime, _
                           IIf(hwZone.IsDaylightSavingTime(hwTime), hwZone.DaylightName, hwZone.StandardName), _
                           TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local))
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.")
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Registry data on the Hawaiian Standard Time zone has been corrupted.")
      End Try                     