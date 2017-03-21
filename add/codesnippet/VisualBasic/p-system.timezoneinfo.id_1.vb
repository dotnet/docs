      Dim zones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      Console.WriteLine("The local system has the following {0} time zones", zones.Count)
      For Each zone As TimeZoneInfo In zones
         Console.WriteLine(zone.Id)
      Next