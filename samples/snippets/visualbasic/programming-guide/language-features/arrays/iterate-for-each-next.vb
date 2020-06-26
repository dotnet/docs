
Module IterateWithForEach
   Public Sub Main()
      ' Declare and iterate through a one-dimensional array.
      Dim numbers1 = {10, 20, 30}
      
      For Each number In numbers1
         Console.WriteLine(number)
      Next
      Console.WriteLine()
      
      Dim numbers = {{1, 2}, {3, 4}, {5, 6}}

      For Each number In numbers
         Console.WriteLine(number)
      Next
   End Sub
End Module
' The example displays the following output:
'  10
'  20
'  30
'
'  1
'  2
'  3
'  4
'  5
'  6
