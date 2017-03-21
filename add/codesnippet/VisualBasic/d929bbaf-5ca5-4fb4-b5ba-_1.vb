      Dim currentTime As Date = Date.Now
      Console.WriteLine("Current Times:")
      Console.WriteLine()
      Console.WriteLine("Los Angeles: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Pacific Standard Time"))
      Console.WriteLine("Chicago: {0}", _ 
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time"))
      Console.WriteLine("New York: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Eastern Standard Time"))
      Console.WriteLine("London: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "GMT Standard Time"))
      Console.WriteLine("Moscow: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Russian Standard Time"))
      Console.WriteLine("New Delhi: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "India Standard Time"))
      Console.WriteLine("Beijing: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "China Standard Time"))
      Console.WriteLine("Tokyo: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Tokyo Standard Time"))