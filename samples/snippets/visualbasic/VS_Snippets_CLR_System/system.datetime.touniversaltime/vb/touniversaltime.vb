' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim date1 As Date = #3/21/2006 2:00AM#
      
      Console.WriteLine(date1.ToUniversalTime())
      Console.WriteLine(TimeZoneInfo.ConvertTimeToUtc(date1))
      
      Dim tz As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")  
      Console.WriteLine(TimeZoneInfo.ConvertTimeToUtc(date1, tz))     
   End Sub
End Module
' The example displays the following output on Windows XP systems:
'       3/21/2006 9:00:00 AM
'       3/21/2006 9:00:00 AM
'       3/21/2006 10:00:00 AM
' </Snippet1>
