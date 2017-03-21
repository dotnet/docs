      Dim localZone As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine("The {0} time zone is {1}:{2} {3} than Coordinated Universal Time.", _ 
                        localZone.StandardName, _
                        Math.Abs(localZone.BaseUtcOffset.Hours), _
                        Math.Abs(localZone.BaseUtcOffset.Minutes), _
                        IIf(localZone.BaseUtcOffset >= TimeSpan.Zero, "later", "earlier"))