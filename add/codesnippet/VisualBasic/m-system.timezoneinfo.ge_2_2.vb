      ShowPossibleUtcTimes(#11/4/2007 1:00:00#, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 01, 00, 00, DateTimeKind.Local), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 00, 00, 00, DateTimeKind.Local), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()                     
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 01, 00, 00, DateTimeKind.Unspecified), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 07, 00, 00, DateTimeKind.Utc), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      ' 
      ' This example produces the following output if run in the Pacific time zone:
      '
      '    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      ' 
      '    11/4/2007 1:00:00 AM Pacific Standard Time is not ambiguous in time zone (GMT-06:00) Central Time (US & Canada).
      ' 
      '    11/4/2007 12:00:00 AM local time maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      ' 
      '    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      ' 
      '    11/4/2007 7:00:00 AM UTC maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC