      Dim tt1 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#02:00:00AM#, 11, 03)
      Dim tt2 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#02:00:00AM#, 11, 03)
      Dim tt3 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 10, 05, DayOfWeek.Sunday)
      Dim tz As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine(tt1.Equals(tz))          ' Returns False (overload with argument of type Object)
      Console.WriteLine(tt1.Equals(tt1))         ' Returns True (an object always equals itself)
      Console.WriteLine(tt1.Equals(tt2))         ' Returns True (identical property values)
      Console.WriteLine(tt1.Equals(tt3))         ' Returns False (different property values)