' The following code example calls IsLeapDay for the last day of the second month (February) for five years in each of the eras.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesTaiwanCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a TaiwanCalendar.
      Dim myCal As New TaiwanCalendar()

      ' Creates a holder for the last day of the second month (February).
      Dim iLastDay As Integer

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 90 To 94
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Checks five years in the current era.
      Console.Write("CurrentEra:")
      For y = 90 To 94
         iLastDay = myCal.GetDaysInMonth(y, 2, TaiwanCalendar.CurrentEra)
         Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapDay(y, 2, iLastDay, TaiwanCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Checks five years in each of the eras.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 90 To 94
            iLastDay = myCal.GetDaysInMonth(y, 2, myCal.Eras(i))
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapDay(y, 2, iLastDay, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesTaiwanCalendar


'This code produces the following output.
'
'YEAR            90      91      92      93      94
'CurrentEra:     False   False   False   True    False
'Era 1:          False   False   False   True    False

' </snippet1>
