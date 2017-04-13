' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim faIR As New CultureInfo("fa-IR")
      Dim umAlQura As Calendar = faIR.DateTimeFormat.Calendar
      Dim dat As New DateTime(1395, 8, 18, umAlQura)
      Console.WriteLine("Using the Umm-al-Qura calendar:")
      Console.WriteLine("Date: {0}", dat.ToString("d", faIR))
      Console.WriteLine("Day of Week: {0}", umAlQura.GetDayOfWeek(dat))
      Console.WriteLine("Week of year: {0}", 
                        umAlQura.GetWeekOfYear(dat, CalendarWeekRule.FirstDay, 
                                               DayOfWeek.Sunday))
      Console.WriteLine()
      
      Dim greg As Calendar = New GregorianCalendar() 
      Console.WriteLine("Using the Gregorian calendar:")
      Console.WriteLine("Date: {0:d}", dat)
      Console.WriteLine("Day of Week: {0}", dat.DayOfWeek)
      Console.WriteLine("Week of year: {0}", 
                         greg.GetWeekOfYear(dat, CalendarWeekRule.FirstDay, 
                                            DayOfWeek.Sunday))
   End Sub
End Module
' The example displays the following output:
'       Using the Umm-al-Qura calendar:
'       Date: 18/08/1395
'       Day of Week: Tuesday
'       Week of year: 34
'       
'       Using the Gregorian calendar:
'       Date: 11/8/2016
'       Day of Week: Tuesday
'       Week of year: 46
' </Snippet5>
