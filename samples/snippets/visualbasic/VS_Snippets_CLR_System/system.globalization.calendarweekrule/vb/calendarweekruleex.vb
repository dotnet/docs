' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   
   Dim cal As New GregorianCalendar()
   
   Public Sub Main()
      Dim dat As Date = #01/05/2013#
      Dim firstDay As DayOfWeek = DayOfWeek.Sunday
      Dim rule As CalendarWeekRule
      
      rule = CalendarWeekRule.FirstFullWeek
      ShowWeekNumber(dat, rule, firstDay)
      
      rule = CalendarWeekRule.FirstFourDayWeek
      ShowWeekNumber(dat, rule, firstDay)

      Console.WriteLine()
      dat = #1/03/2010#
      ShowWeekNumber(dat, rule, firstDay)
   End Sub
   
   Private Sub ShowWeekNumber(dat As Date, rule As CalendarWeekRule, 
                              firstDay As DayOfWeek)
      Console.WriteLine("{0:d} with {1:F} rule and {2:F} as first day of week: week {3}",
                        dat, rule, firstDay, cal.GetWeekOfYear(dat, rule, firstDay))
   End Sub   
End Module
' The example displays the following output:
'       1/5/2013 with FirstFullWeek rule and Sunday as first day of week: week 53
'       1/5/2013 with FirstFourDayWeek rule and Sunday as first day of week: week 1
'       
'       1/3/2010 with FirstFourDayWeek rule and Sunday as first day of week: week 1
' </Snippet1>
