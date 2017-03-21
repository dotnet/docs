      Dim workDay As New DateTimeOffset(#3/1/2008 9:00AM#, _
                         DateTimeOffset.Now.Offset)
      Dim month As Integer = workDay.Month
      ' Start with the first Monday of the month
      If workDay.DayOfWeek <> DayOfWeek.Monday Then
         If workDay.DayOfWeek = DayOfWeek.Sunday Then
            workDay = workDay.AddDays(1)
         Else   
            workDay = workDay.AddDays(8 - CInt(workDay.DayOfWeek))
         End If
      End If
      Console.WriteLine("Beginning of Work Week In {0:MMMM} {0:yyyy}:", workDay)
      ' Add one week to the current date 
      Do While workDay.Month = month
         Console.WriteLine("   {0:dddd}, {0:MMMM}{0: d}", workDay)
         workDay = workDay.AddDays(7)
      Loop        
      ' The example produces the following output:
      '    Beginning of Work Week In March 2008:
      '       Monday, March 3
      '       Monday, March 10
      '       Monday, March 17
      '       Monday, March 24
      '       Monday, March 31             