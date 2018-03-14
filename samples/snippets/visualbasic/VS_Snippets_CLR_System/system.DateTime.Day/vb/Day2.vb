' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Threading

Module modMain
   Public Sub Main()
      ' <Snippet2>
      Dim originalCulture As CultureInfo = Thread.CurrentThread.CurrentCulture

      ' Change current culture to ar-SA.
      Dim ci As New CultureInfo("ar-SA")
      Thread.CurrentThread.CurrentCulture = ci
      
      Dim hijriDate As New Date(1430, 1, 17, _
                                Thread.CurrentThread.CurrentCulture.Calendar)
      ' Display date (uses calendar of current culture by default).
      Console.WriteLine(hijriDate.ToString("dd-MM-yyyy"))
      ' Displays 17-01-1430.

      ' Display day of 17th of Muharram
      Console.WriteLine(hijriDate.Day)
      ' Displays 13 (corresponding day of January in Gregorian calendar).
      
      ' Display day of 17th of Muharram in Hijri calendar.
      Console.WriteLine(Thread.CurrentThread.CurrentCulture.Calendar.GetDayOfMonth(hijriDate))
      ' Displays 17.
      
      Thread.CurrentThread.CurrentCulture = originalCulture  
      ' </Snippet2>
   End Sub
End Module

