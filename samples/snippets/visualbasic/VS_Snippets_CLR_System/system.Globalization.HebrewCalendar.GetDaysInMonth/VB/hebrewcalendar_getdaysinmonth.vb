' The following code example calls GetDaysInMonth for the second month in each of 5 years in each era.

' <snippet1>
Imports System.Globalization

Public Class SamplesHebrewCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a HebrewCalendar.
      Dim myCal As New HebrewCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 5761 To 5765
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:")
      For y = 5761 To 5765
         Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInMonth(y, 2, HebrewCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Displays the values in the Eras property.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 5761 To 5765
            Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInMonth(y, 2, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub

End Class


'This code produces the following output.
'
'YEAR            5761    5762    5763    5764    5765
'CurrentEra:     29      29      30      30      29
'Era 1:          29      29      30      30      29

' </snippet1>
