        ' Tests for the presence of a CompilerError in the 
        ' collection, and retrieves its index if it is found.
        Dim testError As New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")
        Dim itemIndex As Integer = -1
        If collection.Contains(testError) Then
            itemIndex = collection.IndexOf(testError)
        End If