
Module IterateArray
   Public Sub Main()
      Dim numbers = {{1, 2}, {3, 4}, {5, 6}}

      For index0 = 0 To numbers.GetUpperBound(0)
         For index1 = 0 To numbers.GetUpperBound(1)
            Console.Write($"{numbers(index0, index1)} ")
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
' Output 
'  1 2 
'  3 4 
'  5 6
