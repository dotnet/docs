         TimeZoneInfo thisTimeZone, zone1, zone2;
      
         thisTimeZone = TimeZoneInfo.Local;
         zone1 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
         zone2 = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
         Console.WriteLine(thisTimeZone.Equals(zone1));
         Console.WriteLine(thisTimeZone.Equals(zone2));