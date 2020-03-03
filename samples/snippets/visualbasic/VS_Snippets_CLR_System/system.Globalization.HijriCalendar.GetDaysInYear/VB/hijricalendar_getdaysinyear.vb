' The following code example calls GetDaysInYear for 5 years in each era.

' <snippet1>
Imports System.Globalization

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

      ' Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:")
      For y = 1421 To 1425
         Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInYear(y, HijriCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Displays the values in the Eras property.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 1421 To 1425
            Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub

End Class


'This code produces the following output. The results might vary depending on
'the settings in Regional and Language Options (or Regional Options or Regional Settings).
'
'YEAR            1421    1422    1423    1424    1425
'CurrentEra:     354     354     355     354     354
'Era 1:          354     354     355     354     354

' </snippet1>
