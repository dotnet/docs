' The following code example prints a DateTime using a GregorianCalendar that is localized.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesGregorianCalendar

   Public Shared Sub Main()
      ' Creates and initializes three different CultureInfo.
      Dim myCIdeDE As New CultureInfo("de-DE", False)
      Dim myCIenUS As New CultureInfo("en-US", False)
      Dim myCIfrFR As New CultureInfo("fr-FR", False)
      Dim myCIruRU As New CultureInfo("ru-RU", False)

      ' Creates a Localized GregorianCalendar.
      ' GregorianCalendarTypes.Localized is the default when using the GregorianCalendar constructor without parameters.
      Dim myCal = New GregorianCalendar()

      ' Sets the DateTimeFormatInfo.Calendar property to a Localized GregorianCalendar.
      ' Localized GregorianCalendar is the default calendar for de-DE, en-US, and fr-FR,
      myCIruRU.DateTimeFormat.Calendar = myCal

      ' Creates a DateTime.
      Dim myDT As New DateTime(2002, 1, 3, 13, 30, 45)

      ' Displays the DateTime.
      Console.WriteLine("de-DE: {0}", myDT.ToString("F", myCIdeDE))
      Console.WriteLine("en-US: {0}", myDT.ToString("F", myCIenUS))
      Console.WriteLine("fr-FR: {0}", myDT.ToString("F", myCIfrFR))
      Console.WriteLine("ru-RU: {0}", myDT.ToString("F", myCIruRU))
   End Sub
End Class
' This example displays the following output:
'    de-DE: Donnerstag, 3. Januar 2002 13:30:45
'    en-US: Thursday, January 03, 2002 1:30:45 PM
'    fr-FR: jeudi 3 janvier 2002 13:30:45
'    ru-RU: 3 января 2002 г. 13:30:45
' </snippet1>
