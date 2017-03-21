         TimeZoneInfo localZone = TimeZoneInfo.Local;
         Console.WriteLine("The {0} time zone is {1}:{2} {3} than Coordinated Universal Time.",  
                           localZone.DisplayName, 
                           Math.Abs(localZone.BaseUtcOffset.Hours), 
                           Math.Abs(localZone.BaseUtcOffset.Minutes), 
                           (localZone.BaseUtcOffset >= TimeSpan.Zero) ? "later" : "earlier");