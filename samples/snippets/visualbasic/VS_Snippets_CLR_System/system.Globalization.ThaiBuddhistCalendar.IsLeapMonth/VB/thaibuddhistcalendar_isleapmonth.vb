' The following code example calls IsLeapMonth for all the months in five years in the current era.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesThaiBuddhistCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a ThaiBuddhistCalendar.
      Dim myCal As New ThaiBuddhistCalendar()

      ' Checks all the months in five years in the current era.
      Dim iMonthsInYear As Integer
      Dim y As Integer
      For y = 2544 To 2548
         Console.Write("{0}:" + ControlChars.Tab, y)
         iMonthsInYear = myCal.GetMonthsInYear(y, ThaiBuddhistCalendar.CurrentEra)
         Dim m As Integer
         For m = 1 To iMonthsInYear
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapMonth(y, m, ThaiBuddhistCalendar.CurrentEra))
         Next m
         Console.WriteLine()
      Next y

   End Sub 'Main 

End Class 'SamplesThaiBuddhistCalendar


'This code produces the following output.
'
'2544:           False   False   False   False   False   False   False   False   False   False   False   False
'2545:           False   False   False   False   False   False   False   False   False   False   False   False
'2546:           False   False   False   False   False   False   False   False   False   False   False   False
'2547:           False   False   False   False   False   False   False   False   False   False   False   False
'2548:           False   False   False   False   False   False   False   False   False   False   False   False

' </snippet1>
