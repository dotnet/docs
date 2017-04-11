' Visual Basic .NET Document
Option Strict On

Module modMain
   Public Sub Main()
      ' <Snippet1>
      Dim numbersToConvert() As Long = {162345, 32183, -54000}
      Dim newNumber As Int16
      For Each number As Long In NumbersToConvert
         If number >= Int16.MinValue And number <= Int16.MaxValue Then
            newNumber = Convert.ToInt16(number)
            Console.WriteLine("Successfully converted {0} to an Int16.", _
                              newNumber)
         Else
            Console.WriteLine("Unable to convert {0} to an Int16.", number)
         End If                     
      Next
      ' The example displays the following output to the console:
      '       Unable to convert 162345 to an Int16.
      '       Successfully converted 32183 to an Int16.
      '       Unable to convert -54000 to an Int16.   
      ' </Snippet1>
   End Sub
End Module

