  Function allOnes(ByVal n As Integer) As Integer()
      Dim i As Integer, iArray(n) As Integer
      For i = 0 To n - 1
          iArray(i) = 1
      Next i
      Return iArray
  End Function