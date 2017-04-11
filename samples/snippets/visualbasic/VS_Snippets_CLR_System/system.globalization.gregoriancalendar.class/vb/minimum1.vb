' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Thread.CurrentThread.CurrentCulture = New CultureInfo("da-DK")
      
      Dim jc As New JulianCalendar()
      Dim lastDate As New DateTime(1700, 2, 18, jc)
      Console.WriteLine("Last date (Gregorian): {0:d}", lastDate)
      Console.WriteLine("Last date (Julian): {0}-{1}-{2}", jc.GetDayOfMonth(lastDate),
                        jc.GetMonth(lastDate), jc.GetYear(lastDate))
      Console.WriteLine()
      
      Dim firstDate As DateTime = lastDate.AddDays(1)
      Console.WriteLine("First date (Gregorian): {0:d}", firstDate)
      Console.WriteLine("First date (Julian): {0}-{1}-{2}",  jc.GetDayOfMonth(firstDate),
                        jc.GetMonth(firstDate), jc.GetYear(firstDate))
   End Sub
End Module
' The example displays the following output:
'       Last date (Gregorian): 28-02-1700
'       Last date (Julian): 18-2-1700
'       
'       First date (Gregorian): 01-03-1700
'       First date (Julian): 19-2-1700
' </Snippet1>
