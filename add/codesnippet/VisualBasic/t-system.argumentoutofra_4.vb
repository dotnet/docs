      Dim squares As New List(Of Integer)
      For ctr As Integer = 0 To numbers.Count - 1
         squares.Add(CInt(numbers(ctr) ^ 2)) 
      Next