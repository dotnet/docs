' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim date1 As New Date(2010, 3, 14, 2, 30, 0, DateTimeKind.Local)
      Console.WriteLine("Invalid time: {0}", _
                        TimeZoneInfo.Local.IsInvalidTime(date1))
      Dim utcDate1 As Date = date1.ToUniversalTime()
      Dim date2 As Date = utcDate1.ToLocalTime()
      Console.WriteLine("{0} --> {1}", date1, date2)      
   End Sub
End Module
' The example displays the following output:
'       Invalid time: True
'       3/14/2010 2:30:00 AM --> 3/14/2010 3:30:00 AM
' </Snippet1>
