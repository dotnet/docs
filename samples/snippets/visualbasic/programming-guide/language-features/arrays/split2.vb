
Module Example
   Public Sub Main()
      Dim rnd As New Random()
      
      ' Create an array of 100 elements.
      Dim arr(99) As String
      ' Populate each element with an arbitrary ASCII character.
      For ctr = 0 To arr.GetUpperBound(0)
         arr(ctr) = ChrW(Rnd.Next(&h21, &h7F))
      Next
      ' Get a random number that will represent the point to insert the delimiter.
      arr(rnd.Next(0, arr.GetUpperBound(0))) = "zzz"

      ' Find the delimiter.
      Dim location = Array.FindIndex(arr, Function(x) x = "zzz")

      ' Create the arrays.
      Dim arr1(location - 1) As String
      Dim arr2(arr.GetUpperBound(0) - location - 1) As String
      
      ' Populate the two arrays.
      Array.Copy(arr, 0, arr1, 0, location)
      Array.Copy(arr, location + 1, arr2, 0, arr.GetUpperBound(0) - location)
   End Sub
End Module

