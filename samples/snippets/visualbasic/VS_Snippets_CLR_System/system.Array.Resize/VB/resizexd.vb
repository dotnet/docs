' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim arr(9, 1) As Integer
      For n1 As Integer = 0 To arr.GetUpperBound(0)
         arr(n1, 0) = n1
         arr(n1, 1) = n1 * 2
      Next 

      ' Make a 2-D array larger in the first dimension.
      arr = CType(ResizeArray(arr, { 12, 2} ), Integer(,))
      For ctr = 0 To arr.GetUpperBound(0)
         Console.WriteLine("{0}: {1}, {2}", ctr, arr(ctr, 0), arr(ctr, 1))
      Next
      Console.WriteLine()
      
      ' Make a 2-D array smaller in the first dimension.
      arr = CType(ResizeArray(arr, { 2, 2} ), Integer(,))
      For ctr = 0 To arr.GetUpperBound(0)
         Console.WriteLine("{0}: {1}, {2}", ctr, arr(ctr, 0), arr(ctr, 1))
      Next
   End Sub

   Private Function ResizeArray(arr As Array, newSizes() As Integer) As Array
      If newSizes.Length <> arr.Rank Then
         Throw New ArgumentException("arr must have the same number of dimensions " +
                                     "as there are elements in newSizes", "newSizes") 
      End If 

      Dim temp As Array = Array.CreateInstance(arr.GetType().GetElementType(), newSizes)
      Dim length As Integer = If(arr.Length <= temp.Length, arr.Length, temp.Length )
      Array.ConstrainedCopy(arr, 0, temp, 0, length)
      Return temp
   End Function
End Module
' The example displays the following output:
'       0: 0, 0
'       1: 1, 2
'       2: 2, 4
'       3: 3, 6
'       4: 4, 8
'       5: 5, 10
'       6: 6, 12
'       7: 7, 14
'       8: 8, 16
'       9: 9, 18
'       10: 0, 0
'       11: 0, 0
'       
'       0: 0, 0
'       1: 1, 2
' </Snippet2>
