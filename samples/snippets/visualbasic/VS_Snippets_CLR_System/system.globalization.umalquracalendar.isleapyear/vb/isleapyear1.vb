' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cal As New UmAlQuraCalendar()
      Dim currentYear As Integer = cal.GetYear(Date.Now)
      
      For year As Integer = currentYear To currentYear + 9
         Console.WriteLine("{0:d4}: {1} days {2}", year, 
                           cal.GetDaysInYear(year, UmAlQuraCalendar.UmAlQuraEra), 
                           If(cal.IsLeapYear(year, UmAlQuraCalendar.UmAlQuraEra),
                              "(Leap Year)", ""))        
      Next   
   End Sub
End Module
' The example displays the following output:
'       1431: 354 days
'       1432: 354 days
'       1433: 355 days (Leap Year)
'       1434: 354 days
'       1435: 355 days (Leap Year)
'       1436: 354 days
'       1437: 354 days
'       1438: 354 days
'       1439: 355 days (Leap Year)
'       1440: 354 days
' </Snippet1>

