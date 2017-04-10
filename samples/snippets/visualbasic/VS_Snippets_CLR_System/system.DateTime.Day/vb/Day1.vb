' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   Public Sub Main()
      ' <Snippet1>
      ' Return day of 1/13/2009.
      Dim dateGregorian As Date = #1/13/2009#
      Console.WriteLine(dateGregorian.Day)
      ' Displays 13 (Gregorian date).
      
      ' Create date of 1/13/2009 using Hijri calendar.
      Dim hijri As New HijriCalendar()
      Dim dateHijri As Date = New Date(1430, 1, 17, hijri)
      ' Return day of date created using Hijri calendar.
      Console.WriteLine(dateHijri.Day)                   
      ' Displays 13 (Gregorian date).
      
      ' Display day of date in Hijri calendar.
      Console.WriteLine(hijri.GetDayOfMonth(dateHijri))  
      ' Displays 17 (Hijri date).
      ' </Snippet1>
   End Sub
End Module

