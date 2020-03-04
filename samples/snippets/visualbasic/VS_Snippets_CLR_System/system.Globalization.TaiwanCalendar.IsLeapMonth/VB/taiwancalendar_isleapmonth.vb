' The following code example calls IsLeapMonth for all the months in five years in the current era.

' <snippet1>
Imports System.Globalization

Public Class SamplesTaiwanCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a TaiwanCalendar.
      Dim myCal As New TaiwanCalendar()

      ' Checks all the months in five years in the current era.
      Dim iMonthsInYear As Integer
      Dim y As Integer
      For y = 90 To 94
         Console.Write("{0}:" + ControlChars.Tab, y)
         iMonthsInYear = myCal.GetMonthsInYear(y, TaiwanCalendar.CurrentEra)
         Dim m As Integer
         For m = 1 To iMonthsInYear
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapMonth(y, m, TaiwanCalendar.CurrentEra))
         Next m
         Console.WriteLine()
      Next y

   End Sub

End Class


'This code produces the following output.
'
'90:             False   False   False   False   False   False   False   False   False   False   False   False
'91:             False   False   False   False   False   False   False   False   False   False   False   False
'92:             False   False   False   False   False   False   False   False   False   False   False   False
'93:             False   False   False   False   False   False   False   False   False   False   False   False
'94:             False   False   False   False   False   False   False   False   False   False   False   False

' </snippet1>
