' The following code example calls IsLeapYear for five years in each of the eras.

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

      ' Checks five years in the current era.
      Console.Write("CurrentEra:")
      For y = 5761 To 5765
         Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapYear(y, HebrewCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Checks five years in each of the eras.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 5761 To 5765
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub

End Class


'This code produces the following output.
'
'YEAR            5761    5762    5763    5764    5765
'CurrentEra:     False   False   True    False   True
'Era 1:          False   False   True    False   True

' </snippet1>
