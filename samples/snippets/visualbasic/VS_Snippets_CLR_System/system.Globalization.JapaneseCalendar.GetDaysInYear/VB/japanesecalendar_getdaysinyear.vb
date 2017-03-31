' The following code example calls GetDaysInYear for 5 years in each era.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesJapaneseCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a JapaneseCalendar.
      Dim myCal As New JapaneseCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 1 To 5
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:")
      For y = 1 To 5
         Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInYear(y, JapaneseCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Displays the values in the Eras property.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 1 To 5
            Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesJapaneseCalendar


'This code produces the following output.
'
'YEAR            1       2       3       4       5
'CurrentEra:     365     365     365     366     365
'Era 4:          365     365     365     366     365
'Era 3:          365     365     366     365     365
'Era 2:          366     365     365     365     366
'Era 1:          366     365     365     365     366

' </snippet1>
