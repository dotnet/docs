        ' Creates an empty CompilerErrorCollection.
        Dim collection As New CompilerErrorCollection()

        ' Adds a CompilerError to the collection.
        collection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))

        ' Adds an array of CompilerError objects to the collection.
        Dim errors As CompilerError() = {New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"), New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")}
        collection.AddRange(errors)

        ' Adds a collection of CompilerError objects to the collection.
        Dim errorsCollection As New CompilerErrorCollection()
        errorsCollection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        errorsCollection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        collection.AddRange(errorsCollection)

        ' Tests for the presence of a CompilerError in the 
        ' collection, and retrieves its index if it is found.
        Dim testError As New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")
        Dim itemIndex As Integer = -1
        If collection.Contains(testError) Then
            itemIndex = collection.IndexOf(testError)
        End If

        ' Copies the contents of the collection, beginning at index 0, 
        ' to the specified CompilerError array.
        ' 'errors' is a CompilerError array.
        collection.CopyTo(errors, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CompilerError at index 0 of the collection.
        collection.Insert(0, New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))

        ' Removes the specified CompilerError from the collection.
        Dim [error] As New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")
        collection.Remove([error])

        ' Removes the CompilerError at index 0.
        collection.RemoveAt(0)