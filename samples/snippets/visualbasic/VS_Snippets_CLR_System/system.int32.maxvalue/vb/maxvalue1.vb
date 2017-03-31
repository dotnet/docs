' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>

' <Snippet1>
Module modMain
   Public Sub Main()
      Dim numbersToConvert() As Long = { 162345, 32183, -54000, Int64.MaxValue\2 }
      Dim newNumber As Integer
      For Each number As Long In NumbersToConvert
         If number >= Int32.MinValue And number <= Int32.MaxValue Then
            newNumber = Convert.ToInt32(number)
            Console.WriteLine("Successfully converted {0} to an Int32.", _
                              newNumber)
         Else
            Console.WriteLine("Unable to convert {0} to an Int32.", number)
         End If                     
      Next
   End Sub
End Module
' The example displays the following output to the console:
'       Successfully converted 162345 to an Int32.
'       Successfully converted 32183 to an Int32.
'       Successfully converted -54000 to an Int32.
'       Unable to convert 4611686018427387903 to an Int32.
' </Snippet1>   

