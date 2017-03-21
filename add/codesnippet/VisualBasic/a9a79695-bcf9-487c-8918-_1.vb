      Dim displayName As String = "(GMT+06:00) Antarctica/Mawson Time"
      Dim standardName As String = "Mawson Time" 
      Dim offset As TimeSpan = New TimeSpan(06, 00, 00)
      Dim mawson As TimeZoneInfo = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName)
      Console.WriteLine("The current time is {0} {1}", _ 
                        TimeZoneInfo.ConvertTime(Date.Now, TimeZoneInfo.Local, mawson), _
                        mawson.StandardName)      