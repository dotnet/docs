      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-6, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-8, 0, 0))
      Console.WriteLine(DateTimeOffset.op_LessThan(date1, date2))  ' Displays False
      Console.WriteLine(DateTimeOffset.op_LessThan(date1, date3))  ' Displays True