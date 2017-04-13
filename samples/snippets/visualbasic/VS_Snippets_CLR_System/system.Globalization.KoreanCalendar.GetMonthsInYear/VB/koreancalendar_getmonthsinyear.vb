' The following code example calls GetMonthsInYear for 5 years in each era.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesKoreanCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a KoreanCalendar.
      Dim myCal As New KoreanCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 4334 To 4338
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:")
      For y = 4334 To 4338
         Console.Write(ControlChars.Tab + "{0}", myCal.GetMonthsInYear(y, KoreanCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Displays the values in the Eras property.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 4334 To 4338
            Console.Write(ControlChars.Tab + "{0}", myCal.GetMonthsInYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesKoreanCalendar


'This code produces the following output.
'
'YEAR            4334    4335    4336    4337    4338
'CurrentEra:     12      12      12      12      12
'Era 1:          12      12      12      12      12

' </snippet1>
