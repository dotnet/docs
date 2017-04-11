' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
      Dim date1 As Date = #1/1/2011#
      Dim cal As Calendar = dfi.Calendar
      
      Console.WriteLine("{0:d}: Week {1} ({2})", date1, 
                        cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, 
                                          dfi.FirstDayOfWeek),
                        cal.ToString().Substring(cal.ToString().LastIndexOf(".") + 1))       
   End Sub
End Module
' The example displays the following output:
'       1/1/2011: Week 1 (GregorianCalendar)
' </Snippet2>
