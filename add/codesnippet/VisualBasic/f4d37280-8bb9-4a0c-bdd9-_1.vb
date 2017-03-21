        ' Removes the specified CompilerError from the collection.
        Dim [error] As New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")
        collection.Remove([error])