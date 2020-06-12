
Module Example
   Public Sub Main()
      SizeInDeclaration()
      SizeAsNew()
      SizeWithLiterals()   
      SizeWithNestedLiterals()
      SizeWithTypeInference()
   End Sub
   
   Private Sub SizeInDeclaration()
      ' <Snippet1>
      ' Declare an array with 10 elements.
      Dim cargoWeights(9) As Double               
      ' Declare a 24 x 2 array.
      Dim hourlyTemperatures(23, 1) As Integer
      ' Declare a jagged array with 31 elements.
      Dim januaryInquiries(30)() As String
      ' </Snippet1>   
   End Sub
   
   Private Sub SizeAsNew()
      ' <Snippet2>
      ' Declare an array with 10 elements.
      Dim cargoWeights() As Double = New Double(9) {}
      ' Declare a 24 x 2 array.
      Dim hourlyTemperatures(,) As Integer = New Integer(23, 1) {}
      ' Declare a jagged array with 31 elements. 
      Dim januaryInquiries()() As String = New String(30)() {}
      ' </Snippet2>
      
      '<Snippet3>
      ' Assign a new array size and retain the current values.
      ReDim Preserve cargoWeights(20)
      ' Assign a new array size and retain only the first five values.
      ReDim Preserve cargoWeights(4)
      ' Assign a new array size and discard all current element values.
      ReDim cargoWeights(15)
      '</Snippet3>
   End Sub

   Private Sub SizeWithLiterals()
      '<Snippet4>
      ' Array literals with explicit type definition.
      Dim numbers = New Integer() {1, 2, 4, 8}
      ' Array literals with type inference.
      Dim doubles = {1.5, 2, 9.9, 18}
      ' Array literals with explicit type definition.
      Dim articles() As String = { "the", "a", "an" }
      
      ' Array literals with explicit widening type definition.
      Dim values() As Double = { 1, 2, 3, 4, 5 }
      '</Snippet4>
   End Sub

   Private Sub SizeWithNestedLiterals()
      '<Snippet5>
      ' Create and populate a 2 x 2 array.
      Dim grid1 = {{1, 2}, {3, 4}}
      ' Create and populate a 2 x 2 array with 3 elements.
      Dim grid2(,) = {{1, 2}, {3, 4}, {5, 6}}
      '</Snippet5>
   End Sub 

   Private Sub SizeWithTypeInference()
      '<Snippet6>
      Dim arr = {{1, 2.0}, {3, 4}, {5, 6}, {7, 8}}
      '</Snippet6>
   End Sub
End Module

