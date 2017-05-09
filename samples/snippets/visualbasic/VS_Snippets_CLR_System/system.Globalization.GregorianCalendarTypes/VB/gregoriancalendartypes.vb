' The following code example demonstrates how to determine the GregorianCalendar version supported by the culture.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesCultureInfo

   Public Shared Sub Main()

      ' Gets the calendars supported by the ar-SA culture.
      Dim myOptCals As Calendar() = New CultureInfo("ar-SA").OptionalCalendars

      ' Checks which ones are GregorianCalendar then determines the GregorianCalendar version.
      Console.WriteLine("The ar-SA culture supports the following calendars:")
      Dim cal As Calendar
      For Each cal In  myOptCals
         If cal.GetType() Is GetType(GregorianCalendar)  Then
            Dim myGreCal As GregorianCalendar = CType(cal, GregorianCalendar)
            Dim calType As GregorianCalendarTypes = myGreCal.CalendarType
            Console.WriteLine("   {0} ({1})", cal, calType)
         Else
            Console.WriteLine("   {0}", cal)
         End If
      Next cal

   End Sub 'Main 

End Class 'SamplesCultureInfo


'This code produces the following output.
'
'The ar-SA culture supports the following calendars:
'   System.Globalization.HijriCalendar
'   System.Globalization.GregorianCalendar (USEnglish)
'   System.Globalization.GregorianCalendar (MiddleEastFrench)
'   System.Globalization.GregorianCalendar (Arabic)
'   System.Globalization.GregorianCalendar (Localized)
'   System.Globalization.GregorianCalendar (TransliteratedFrench)

' </snippet1>
