      TimeZoneInfo.TransitionTime tt1 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 02, 00, 00), 11, 03);
      TimeZoneInfo.TransitionTime tt2 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 02, 00, 00), 11, 03);
      TimeZoneInfo.TransitionTime tt3 = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 02, 00, 00), 10, 05, DayOfWeek.Sunday);
      TimeZoneInfo tz = TimeZoneInfo.Local;
      Console.WriteLine(tt1.Equals(tz));         // Returns False (overload with argument of type Object)
      Console.WriteLine(tt1.Equals(tt1));        // Returns True (an object always equals itself)
      Console.WriteLine(tt1.Equals(tt2));        // Returns True (identical property values)
      Console.WriteLine(tt1.Equals(tt3));        // Returns False (different property values)