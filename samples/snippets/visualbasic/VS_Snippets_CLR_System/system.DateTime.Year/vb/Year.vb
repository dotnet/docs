' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module YearMethodExample
   Public Sub Main()
      ' Initialize date variable and display year
      Dim date1 As Date = #01/01/2008 6:32AM#
      Console.WriteLine(date1.Year)       ' Displays 2008
      
      ' Set culture to th-TH
      Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")
      Console.WriteLine(date1.Year)        ' Displays 2008
      
      ' display year using current culture's calendar 
      Dim thaiCalendar As Calendar = CultureInfo.CurrentCulture.Calendar
      Console.WriteLine(thaiCalendar.GetYear(date1))    ' Displays 2551
      
      ' display year using Persian calendar
      Dim persianCalendar As New PersianCalendar()
      Console.WriteLine(persianCalendar.GetYear(date1))  ' Displays 1386 
   End Sub
End Module
' </Snippet1>
