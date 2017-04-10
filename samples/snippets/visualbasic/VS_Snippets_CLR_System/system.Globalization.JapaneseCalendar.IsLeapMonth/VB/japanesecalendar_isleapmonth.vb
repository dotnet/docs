' The following code example calls IsLeapMonth for all the months in five years in the current era.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesJapaneseCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a JapaneseCalendar.
      Dim myCal As New JapaneseCalendar()

      ' Checks all the months in five years in the current era.
      Dim iMonthsInYear As Integer
      Dim y As Integer
      For y = 1 To 5
         Console.Write("{0}:" + ControlChars.Tab, y)
         iMonthsInYear = myCal.GetMonthsInYear(y, JapaneseCalendar.CurrentEra)
         Dim m As Integer
         For m = 1 To iMonthsInYear
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapMonth(y, m, JapaneseCalendar.CurrentEra))
         Next m
         Console.WriteLine()
      Next y

   End Sub 'Main 

End Class 'SamplesJapaneseCalendar


'This code produces the following output.
'
'1:              False   False   False   False   False   False   False   False   False   False   False   False
'2:              False   False   False   False   False   False   False   False   False   False   False   False
'3:              False   False   False   False   False   False   False   False   False   False   False   False
'4:              False   False   False   False   False   False   False   False   False   False   False   False
'5:              False   False   False   False   False   False   False   False   False   False   False   False

' </snippet1>
