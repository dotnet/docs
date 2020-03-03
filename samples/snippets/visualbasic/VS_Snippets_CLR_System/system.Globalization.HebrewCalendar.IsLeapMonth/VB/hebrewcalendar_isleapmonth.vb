' The following code example calls IsLeapMonth for all the months in five years in the current era.

' <snippet1>
Imports System.Globalization

Public Class SamplesHebrewCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a HebrewCalendar.
      Dim myCal As New HebrewCalendar()

      ' Checks all the months in five years in the current era.
      Dim iMonthsInYear As Integer
      Dim y As Integer
      For y = 5761 To 5765
         Console.Write("{0}:" + ControlChars.Tab, y)
         iMonthsInYear = myCal.GetMonthsInYear(y, HebrewCalendar.CurrentEra)
         Dim m As Integer
         For m = 1 To iMonthsInYear
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapMonth(y, m, HebrewCalendar.CurrentEra))
         Next m
         Console.WriteLine()
      Next y

   End Sub

End Class


'This code produces the following output.
'
'5761:           False   False   False   False   False   False   False   False   False   False   False   False
'5762:           False   False   False   False   False   False   False   False   False   False   False   False
'5763:           False   False   False   False   False   False   True    False   False   False   False   False   False
'5764:           False   False   False   False   False   False   False   False   False   False   False   False
'5765:           False   False   False   False   False   False   True    False   False   False   False   False   False

' </snippet1>
