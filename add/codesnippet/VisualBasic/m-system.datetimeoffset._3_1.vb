      Dim date1 As New DateTimeOffset(#1/1/2008 1:32:45PM#, _
                   New TimeSpan(-5, 0, 0)) 
      Dim interval1 As New TimeSpan(202, 3, 30, 0)
      Dim interval2 As New TimeSpan(5, 0, 0, 0)      
      Dim date2 As DateTimeOffset 
      
      Console.WriteLine(date1)         ' Displays 1/1/2008 1:32:45 PM -05:00
      date2 = date1 + interval1
      Console.WriteLine(date2)         ' Displays 7/21/2008 5:02:45 PM -05:00
      date2 += interval2
      Console.WriteLine(date2)         ' Displays 7/26/2008 5:02:45 PM -05:00     