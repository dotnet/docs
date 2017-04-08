' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim date1 As Date = New Date(2011, 4, 3, New GregorianCalendar())
      Dim cal As New UmAlQuraCalendar()
      
      Console.WriteLine("{0:MMMM d, yyyy} in the Gregorian calendar is equivalent to:", date1)
      DisplayCalendarInfo(cal, date1)
            
      ' Add 2 years and 10 months by calling UmAlQuraCalendar methods.
      date1 = cal.AddYears(date1, 2)
      date1 = cal.AddMonths(date1, 10)       

      Console.WriteLine("After adding 2 years and 10 months in the {0} calendar,", 
                        GetCalendarName(cal))
      Console.WriteLine("{0:MMMM d, yyyy} in the Gregorian calendar is equivalent to:", date1)
      DisplayCalendarInfo(cal, date1)
   End Sub
   
   Private Sub DisplayCalendarInfo(cal As Calendar, date1 As Date)
      Console.WriteLine("   Calendar:   {0}", GetCalendarName(cal))    
      Console.WriteLine("   Era:        {0}", cal.GetEra(date1))
      Console.WriteLine("   Year:       {0}", cal.GetYear(date1))
      Console.WriteLine("   Month:      {0}", cal.GetMonth(date1))
      Console.WriteLine("   DayOfYear:  {0}", cal.GetDayOfYear(date1))
      Console.WriteLine("   DayOfMonth: {0}", cal.GetDayOfMonth(date1))
      Console.WriteLine("   DayOfWeek:  {0}", cal.GetDayOfWeek(date1))
      Console.WriteLine()
   End Sub
   
   Private Function GetCalendarName(cal As Calendar) As String
      Return cal.ToString().Replace("System.Globalization.", "").
             Replace("Calendar", "")   
   End Function
End Module
' The example displays the following output:
'    April 3, 2011 in the Gregorian calendar is equivalent to:
'       Calendar:   UmAlQura
'       Era:        1
'       Year:       1432
'       Month:      4
'       DayOfYear:  118
'       DayOfMonth: 29
'       DayOfWeek:  Sunday
'    
'    After adding 2 years and 10 months in the UmAlQura calendar,
'    January 1, 2014 in the Gregorian calendar is equivalent to:
'       Calendar:   UmAlQura
'       Era:        1
'       Year:       1435
'       Month:      2
'       DayOfYear:  59
'       DayOfMonth: 29
'       DayOfWeek:  Wednesday
' </Snippet1>

