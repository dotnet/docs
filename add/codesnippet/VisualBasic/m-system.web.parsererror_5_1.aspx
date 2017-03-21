    ' Test for the presence of a ParserError in the 
    ' collection, and retrieve its index if it is found.
    Dim testError As New ParserError("Error", "Path", 1)
    Dim itemIndex As Integer = -1
    If collection.Contains(testError) Then
      itemIndex = collection.IndexOf(testError)
    End If