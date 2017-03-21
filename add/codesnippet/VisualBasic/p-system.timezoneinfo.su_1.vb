      Dim zones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      For Each zone As TimeZoneInfo In zones
         If Not zone.SupportsDaylightSavingTime Then _
            Console.WriteLine(zone.DisplayName)
      Next