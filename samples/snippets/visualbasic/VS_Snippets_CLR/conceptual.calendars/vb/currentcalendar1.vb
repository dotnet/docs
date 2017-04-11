' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      ' Change the current culture to zh-TW.
      Dim zhTW As CultureInfo = CultureInfo.CreateSpecificCulture("zh-TW")
      Thread.CurrentThread.CurrentCulture = zhTW
      ' Define a date.
      Dim date1 As Date = #1/16/2011#
      
      ' Display the date using the default (Gregorian) calendar.
      Console.WriteLine("Current calendar: {0}", 
                        zhTW.DateTimeFormat.Calendar)
      Console.WriteLine(date1.ToString("d"))
      
      ' Change the current calendar and display the date.
      zhTW.DateTimeFormat.Calendar = New TaiwanCalendar()      
      Console.WriteLine("Current calendar: {0}", 
                        zhTW.DateTimeFormat.Calendar)
      Console.WriteLine(date1.ToString("d"))
   End Sub
End Module
' The example displays the following output:
'    Current calendar: System.Globalization.GregorianCalendar
'    2011/1/16
'    Current calendar: System.Globalization.TaiwanCalendar
'    100/1/16
' </Snippet5>
