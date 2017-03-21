 Private Sub CopyToArray()
     ' Declare the array.
     Dim myArray(100) As Object
     CType(Me.BindingContext, ICollection).CopyTo(myArray, 0)
 End Sub