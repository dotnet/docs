
Module Example
   Public Sub Main()
      Dim numbers As Integer(,) = GetNumbersMultidim()
      ShowNumbersMultidim(numbers)
   End Sub

   Private Function GetNumbersMultidim() As Integer(,)
      Dim numbers As Integer(,) = {{1, 2}, {3, 4}, {5, 6}}
      Return numbers
   End Function

   Private Sub ShowNumbersMultidim(numbers As Integer(,))
      For index0 = 0 To numbers.GetUpperBound(0)
         For index1 = 0 To numbers.GetUpperBound(1)
            Console.Write($"{numbers(index0, index1)} ")
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'     1 2
'     3 4
'     5 6

