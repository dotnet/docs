' Visual Basic .NET Document
Option Strict On
   
' <Snippet1>
Imports System.Globalization
   
Module Example
   Public Sub Main()
      Dim cal As New UmAlQuraCalendar()
      Dim minDate As Date = cal.MinSupportedDateTime
      Dim maxDate As Date = cal.MaxSupportedDateTime
      
      Console.WriteLine("Range of the Um Al Qura calendar:")
      ' Is UmAlQuraCalendar the current calendar?
      If DateTimeFormatInfo.CurrentInfo.Calendar.ToString().Contains("UmAlQura") Then
         Dim greg As New GregorianCalendar()
         Console.WriteLine("   Minimum: {0:d2}/{1:d2}/{2:d4} {3:HH:mm:ss} Gregorian, {3:MM/dd/yyyy HH:mm:ss} Um Al Qura",
                           greg.GetMonth(minDate), greg.GetDayOfMonth(minDate),
                           greg.GetYear(minDate), minDate)
         Console.WriteLine("   Maximum: {0:d2}/{1:d2}/{2:d4} {3:HH:mm:ss} Gregorian, {3:MM/dd/yyyy HH:mm:ss} Um Al Qura",
                           greg.GetMonth(maxDate), greg.GetDayOfMonth(maxDate),
                           greg.GetYear(maxDate), maxDate)
      ' Is Gregorian the current calendar?
      ElseIf DateTimeFormatInfo.CurrentInfo.Calendar.ToString().Contains("Gregorian") Then         
         Console.WriteLine("   Minimum: {0:d} {0:HH:mm:ss} Gregorian, {1:d2}/{2:d2}/{3:d4} {0:HH:mm:ss} Um Al Qura",
                           minDate, cal.GetMonth(minDate), cal.GetDayOfMonth(minDate),
                           cal.GetYear(minDate))
         Console.WriteLine("   Maximum: {0:d} {0:HH:mm:ss} Gregorian, {1:d2}/{2:d2}/{3:d4} {0:HH:mm:ss} Um Al Qura",
                           maxDate, cal.GetMonth(maxDate), cal.GetDayOfMonth(maxDate),
                           cal.GetYear(maxDate))
      ' Display ranges if some other calendar is current.
      Else
         Dim greg As New GregorianCalendar()          
         Console.WriteLine("   Minimum: {1:d2}/{2:d2}/{3:d4} {0:HH:mm:ss} " + 
                           "Gregorian, {4:d2}/{5:d2}/{6:d4} {0:HH:mm:ss} Um Al Qura",
                           minDate, greg.GetMonth(minDate), greg.GetDayOfMonth(minDate), 
                           greg.GetYear(minDate), cal.GetMonth(minDate), cal.GetDayOfMonth(minDate),
                           cal.GetYear(minDate))
         Console.WriteLine("   Maximum: {1:d2}/{2:d2}/{3:d4} {0:HH:mm:ss} " + 
                           "Gregorian, {4:d2}/{5:d2}/{6:d4} {0:HH:mm:ss} Um Al Qura",
                           maxDate, greg.GetMonth(maxDate), greg.GetDayOfMonth(maxDate), 
                           greg.GetYear(maxDate), cal.GetMonth(maxDate), cal.GetDayOfMonth(maxDate),
                           cal.GetYear(maxDate))
      End If
   End Sub
End Module
' The example displays output similar to the following:
'    Range of the Um Al Qura calendar:
'       Minimum: 4/30/1900 00:00:00 Gregorian, 01/01/1318 00:00:00 Um Al Qura
'       Maximum: 5/13/2029 23:59:59 Gregorian, 12/29/1450 23:59:59 Um Al Qura
' </Snippet1>


