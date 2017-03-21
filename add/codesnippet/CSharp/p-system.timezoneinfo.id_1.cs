         ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
         Console.WriteLine("The local system has the following {0} time zones", zones.Count);
         foreach (TimeZoneInfo zone in zones)
            Console.WriteLine(zone.Id);