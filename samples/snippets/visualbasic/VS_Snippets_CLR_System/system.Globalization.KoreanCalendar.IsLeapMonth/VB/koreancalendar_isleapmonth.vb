' The following code example calls IsLeapMonth for all the months in five years in the current era.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesKoreanCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a KoreanCalendar.
      Dim myCal As New KoreanCalendar()

      ' Checks all the months in five years in the current era.
      Dim iMonthsInYear As Integer
      Dim y As Integer
      For y = 4334 To 4338
         Console.Write("{0}:" + ControlChars.Tab, y)
         iMonthsInYear = myCal.GetMonthsInYear(y, KoreanCalendar.CurrentEra)
         Dim m As Integer
         For m = 1 To iMonthsInYear
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapMonth(y, m, KoreanCalendar.CurrentEra))
         Next m
         Console.WriteLine()
      Next y

   End Sub 'Main 

End Class 'SamplesKoreanCalendar


'This code produces the following output.
'
'4334:           False   False   False   False   False   False   False   False   False   False   False   False
'4335:           False   False   False   False   False   False   False   False   False   False   False   False
'4336:           False   False   False   False   False   False   False   False   False   False   False   False
'4337:           False   False   False   False   False   False   False   False   False   False   False   False
'4338:           False   False   False   False   False   False   False   False   False   False   False   False

' </snippet1>
