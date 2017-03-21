      Dim localTime As Date = #07/12/2007 6:32AM#
      Dim dateAndOffset As New DateTimeOffset(localTime, _
                               TimeZoneInfo.Local.GetUtcOffset(localTime))
      Console.WriteLine(dateAndOffset)
      ' The code produces the following output:
      '    7/12/2007 6:32:00 AM -07:00