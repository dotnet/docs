      Dim fmt As CultureInfo
      Dim year As Integer
      Dim cal As Calendar
      Dim dateInCal As DateTimeOffset
      
      ' Instantiate DateTimeOffset with Hebrew calendar
      year = 5770
      cal = New HebrewCalendar()
      fmt = New CultureInfo("he-IL")
      fmt.DateTimeFormat.Calendar = cal      
      dateInCal = New DateTimeOffset(year, 7, 12, _
                                     15, 30, 0, 0, _
                                     cal, _
                                     New TimeSpan(2, 0, 0))
      ' Display the date in the Hebrew calendar
      Console.WriteLine("Date in Hebrew Calendar: {0:g}", _
                         dateInCal.ToString(fmt))
      ' Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal)
      Console.WriteLine()

      ' Instantiate DateTimeOffset with Hijri calendar
      year = 1431
      cal = New HijriCalendar()
      fmt = New CultureInfo("ar-SA")
      fmt.DateTimeFormat.Calendar = cal
      dateInCal = New DateTimeOffset(year, 7, 12, _
                                     15, 30, 0, 0, _
                                     cal, _
                                     New TimeSpan(2, 0, 0))
      ' Display the date in the Hijri calendar
      Console.WriteLine("Date in Hijri Calendar: {0:g}", _
                         dateInCal.ToString(fmt))
      ' Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal)
      Console.WriteLine()