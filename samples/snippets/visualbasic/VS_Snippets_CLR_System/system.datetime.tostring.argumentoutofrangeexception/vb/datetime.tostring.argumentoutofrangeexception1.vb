' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim jaJP As New CultureInfo("ja-JP")
      jaJP.DateTimeFormat.Calendar = New JapaneseCalendar() 
      Dim date1 As Date = #01/01/1867#

      Try
         Console.WriteLine(date1.ToString(jaJP))
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine("{0:d} is earlier than {1:d} or later than {2:d}", _
                           date1, _
                           jaJP.DateTimeFormat.Calendar.MinSupportedDateTime, _ 
                           jaJP.DateTimeFormat.Calendar.MaxSupportedDateTime) 
      End Try
   End Sub
End Module
' The example displays the following output:
'    1/1/1867 is earlier than 9/8/1868 or later than 12/31/9999
' </Snippet1>
