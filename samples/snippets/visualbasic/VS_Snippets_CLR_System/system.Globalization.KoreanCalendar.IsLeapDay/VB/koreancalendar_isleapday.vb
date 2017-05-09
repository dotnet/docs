' The following code example calls IsLeapDay for the last day of the second month (February) for five years in each of the eras.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesKoreanCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a KoreanCalendar.
      Dim myCal As New KoreanCalendar()

      ' Creates a holder for the last day of the second month (February).
      Dim iLastDay As Integer

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 4334 To 4338
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Checks five years in the current era.
      Console.Write("CurrentEra:")
      For y = 4334 To 4338
         iLastDay = myCal.GetDaysInMonth(y, 2, KoreanCalendar.CurrentEra)
         Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapDay(y, 2, iLastDay, KoreanCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Checks five years in each of the eras.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 4334 To 4338
            iLastDay = myCal.GetDaysInMonth(y, 2, myCal.Eras(i))
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapDay(y, 2, iLastDay, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesKoreanCalendar


'This code produces the following output.
'
'YEAR            4334    4335    4336    4337    4338
'CurrentEra:     False   False   False   True    False
'Era 1:          False   False   False   True    False

' </snippet1>
