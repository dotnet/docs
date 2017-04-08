' <Snippet1>
Class Example
   Public Shared Sub Main()
      Const July As Integer = 7
      Const Feb As Integer = 2

      Dim daysInJuly As Integer = System.DateTime.DaysInMonth(2001, July)
      Console.WriteLine(daysInJuly)
      
      ' daysInFeb gets 28 because the year 1998 was not a leap year.
      Dim daysInFeb As Integer = System.DateTime.DaysInMonth(1998, Feb)
      Console.WriteLine(daysInFeb)
      ' daysInFebLeap gets 29 because the year 1996 was a leap year.
      Dim daysInFebLeap As Integer = System.DateTime.DaysInMonth(1996, Feb)
      Console.WriteLine(daysInFebLeap)
   End Sub
End Class
' The example displays the following output:
'       31
'       28
'       29
' </Snippet1>

