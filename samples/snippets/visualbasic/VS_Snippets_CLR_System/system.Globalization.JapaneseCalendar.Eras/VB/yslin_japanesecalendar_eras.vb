' The following code example displays the values contained in the Eras property.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesJapaneseCalendar

   Public Shared Sub Main()

      ' Creates and initializes a JapaneseCalendar.
      Dim myCal As New JapaneseCalendar()

      ' Displays the values in the Eras property.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.WriteLine("Eras[{0}] = {1}", i, myCal.Eras(i))
      Next i

   End Sub 'Main 

End Class 'SamplesJapaneseCalendar

'This code produces the following output.
'
'Eras[0] = 4
'Eras[1] = 3
'Eras[2] = 2
'Eras[3] = 1
'
' </snippet1>
