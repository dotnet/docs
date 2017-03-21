      string displayName = "(GMT+06:00) Antarctica/Mawson Time";
      string standardName = "Mawson Time"; 
      TimeSpan offset = new TimeSpan(06, 00, 00);
      TimeZoneInfo mawson = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName);
      Console.WriteLine("The current time is {0} {1}", 
                        TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, mawson),
                        mawson.StandardName);      