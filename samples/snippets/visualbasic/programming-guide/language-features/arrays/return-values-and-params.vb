
Module ReturnValuesAndParams
   Public Sub Main()
      Dim numbers As Integer() = GetNumbers()
      ShowNumbers(numbers)
   End Sub

   Private Function GetNumbers() As Integer()
      Dim numbers As Integer() = {10, 20, 30}
      Return numbers
   End Function

   Private Sub ShowNumbers(numbers As Integer())
      For index = 0 To numbers.GetUpperBound(0)
         Console.WriteLine($"{numbers(index)} ")
      Next
   End Sub
End Module
' The example displays the following output:
'   10
'   20
'   30
    