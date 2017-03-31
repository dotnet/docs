' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim faIR As New CultureInfo("fa-IR")
      Dim cal As Calendar = faIR.DateTimeFormat.Calendar
      Dim dat As New DateTime(1395, 8, 18, cal)
      Console.WriteLine("Using the Umm-al-Qura calendar:")
      Console.WriteLine("Date: {0}", dat.ToString("d", faIR))
      Console.WriteLine("Year: {0}", cal.GetYear(dat))
      Console.WriteLine("Leap year: {0}", cal.IsLeapYear(cal.GetYear(dat)))
      Console.WriteLine()
      
      Console.WriteLine("Using the Gregorian calendar:")
      Console.WriteLine("Date: {0:d}", dat)
      Console.WriteLine("Year: {0}", dat.Year)
      Console.WriteLine("Leap year: {0}", DateTime.IsLeapYear(dat.Year))
   End Sub
End Module
' The example displays the following output:
'       Using the Umm-al-Qura calendar:
'       Date: 18/08/1395
'       Year: 1395
'       Leap year: True
'       
'       Using the Gregorian calendar:
'       Date: 11/8/2016
'       Year: 2016
'       Leap year: True
' </Snippet4>
