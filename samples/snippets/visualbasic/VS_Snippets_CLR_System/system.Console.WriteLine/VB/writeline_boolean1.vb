' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      ' Assign 10 random integers to an array.
      Dim rnd As New Random()
      Dim numbers(9) As Integer
      For ctr As Integer = 0 To numbers.GetUpperBound(0)
         numbers(ctr) = rnd.Next
      Next
      
      ' Determine whether the numbers are even or odd.
      For Each number In numbers
         Dim even As Boolean = (number mod 2 = 0)
         Console.WriteLine("Is {0} even:", number)
         Console.WriteLine(even)
         Console.WriteLine()      
      Next
   End Sub
End Module
' </Snippet4>

