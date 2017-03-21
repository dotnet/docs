      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Dim date4 As DateTimeOffset = date1
      Console.WriteLine( _
          DateTimeOffset.op_Inequality(date1, date2))   ' Displays True
      Console.WriteLine( _
          DateTimeOffset.op_Inequality(date1, date3))   ' Displays True
      Console.WriteLine( _
          DateTimeOffset.op_Inequality(date1, date4))   ' Displays False