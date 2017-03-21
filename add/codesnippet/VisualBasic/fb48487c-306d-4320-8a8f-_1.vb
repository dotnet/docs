      ' Define transition times to/from DST
      Dim startTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#04:00:00#, 10, 2, DayOfWeek.Sunday) 
      Dim endTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#3:00:00#, 3, 2, DayOfWeek.Sunday)
      ' Define adjustment rule
      Dim delta As TimeSpan = New TimeSpan(1, 0, 0)
      Dim adjustment As TimeZoneInfo.AdjustmentRule = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#10/01/1999#, Date.MaxValue.Date, delta, startTransition, endTransition)
      ' Create array for adjustment rules
      Dim adjustments() As TimeZoneInfo.AdjustmentRule = {adjustment}
      ' Define other custom time zone arguments
      Dim DisplayName As String = "(GMT-04:00) Antarctica/Palmer Time"
      Dim standardName As String = "Palmer Standard Time"
      Dim daylightName As String = "Palmer Daylight Time"
      Dim offset As TimeSpan = New TimeSpan(-4, 0, 0)
      Dim palmer As TimeZoneInfo = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments)
      Console.WriteLine("The current time is {0} {1}", _ 
                        TimeZoneInfo.ConvertTime(Date.Now, TimeZoneInfo.Local, palmer), _
                        palmer.StandardName)