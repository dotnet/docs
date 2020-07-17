
Module Example
   Public Sub Main()
      ' Create an array of 100 elements.
      Dim arr(99) As Integer
      ' Populate the array.
      Dim rnd As new Random()
      For ctr = 0 To arr.GetUpperBound(0)
         arr(ctr) = rnd.Next()
      Next
      
      ' Determine how many elements should be in each array.
      Dim divisor = 2
      Dim remainder As Integer
      Dim boundary = Math.DivRem(arr.GetLength(0), divisor, remainder)
            
      ' Copy the array.
      Dim arr1(boundary - 1 + remainder), arr2(boundary - 1) as Integer
      Array.Copy(arr, 0, arr1, 0, boundary + remainder)
      Array.Copy(arr, boundary + remainder, arr2, 0, arr.Length - boundary) 
   End Sub
End Module

