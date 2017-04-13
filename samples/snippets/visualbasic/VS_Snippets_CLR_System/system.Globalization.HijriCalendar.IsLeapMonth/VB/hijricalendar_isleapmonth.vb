' The following code example calls IsLeapMonth for all the months in five years in the current era.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesHijriCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a HijriCalendar.
      Dim myCal As New HijriCalendar()

      ' Checks all the months in five years in the current era.
      Dim iMonthsInYear As Integer
      Dim y As Integer
      For y = 1421 To 1425
         Console.Write("{0}:" + ControlChars.Tab, y)
         iMonthsInYear = myCal.GetMonthsInYear(y, HijriCalendar.CurrentEra)
         Dim m As Integer
         For m = 1 To iMonthsInYear
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapMonth(y, m, HijriCalendar.CurrentEra))
         Next m
         Console.WriteLine()
      Next y

   End Sub 'Main 

End Class 'SamplesHijriCalendar


'This code produces the following output.
'
'1421:           False   False   False   False   False   False   False   False   False   False   False   False
'1422:           False   False   False   False   False   False   False   False   False   False   False   False
'1423:           False   False   False   False   False   False   False   False   False   False   False   False
'1424:           False   False   False   False   False   False   False   False   False   False   False   False
'1425:           False   False   False   False   False   False   False   False   False   False   False   False

' </snippet1>
