' The following code example calls IsLeapYear for five years in each of the eras.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesJulianCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a JulianCalendar.
      Dim myCal As New JulianCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 2001 To 2005
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Checks five years in the current era.
      Console.Write("CurrentEra:")
      For y = 2001 To 2005
         Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapYear(y, JulianCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Checks five years in each of the eras.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 2001 To 2005
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesJulianCalendar


'This code produces the following output.
'
'YEAR            2001    2002    2003    2004    2005
'CurrentEra:     False   False   False   True    False
'Era 1:          False   False   False   True    False

' </snippet1>
