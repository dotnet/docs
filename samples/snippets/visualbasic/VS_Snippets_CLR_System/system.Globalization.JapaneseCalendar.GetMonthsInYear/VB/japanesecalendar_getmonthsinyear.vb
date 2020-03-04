Imports System.Globalization

Public Module SamplesJapaneseCalendar   
   Public Sub Main()

      ' Creates and initializes a JapaneseCalendar.
      Dim myCal As New JapaneseCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      For y As Integer = 1 To 5
         Console.Write($"{ControlChars.Tab}{y}")
      Next
      Console.WriteLine()

      ' Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:")
      For y As Integer = 1 To 5
         Console.Write($"{ControlChars.Tab}{myCal.GetMonthsInYear(y, JapaneseCalendar.CurrentEra)}")
      Next
      Console.WriteLine()

      ' Displays the values in the Eras property.
      For i As Integer = 0 To myCal.Eras.Length - 1
         Console.Write($"Era {myCal.Eras(i)}:{ControlChars.Tab}")
         For y As Integer = 1 To 5
            Console.Write($"{ControlChars.Tab}{myCal.GetMonthsInYear(y, myCal.Eras(i))}")
         Next 
         Console.WriteLine()
      Next
   End Sub 
End Module 
