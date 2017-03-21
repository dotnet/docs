         ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
         foreach(TimeZoneInfo zone in zones)
         {
            if (! zone.SupportsDaylightSavingTime)
               Console.WriteLine(zone.DisplayName);
         }