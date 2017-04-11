' The following code example calls IsLeapYear for five years in each of the eras.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesHijriCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a HijriCalendar.
      Dim myCal As New HijriCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 1421 To 1425
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Checks five years in the current era.
      Console.Write("CurrentEra:")
      For y = 1421 To 1425
         Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapYear(y, HijriCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Checks five years in each of the eras.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 1421 To 1425
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesHijriCalendar


'This code produces the following output.
'
'YEAR            1421    1422    1423    1424    1425
'CurrentEra:     False   False   True    False   False
'Era 1:          False   False   True    False   False

' </snippet1>
