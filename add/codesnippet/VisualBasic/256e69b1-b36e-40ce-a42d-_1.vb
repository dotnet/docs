        ' Adds an array of CompilerError objects to the collection.
        Dim errors As CompilerError() = {New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"), New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")}
        collection.AddRange(errors)

        ' Adds a collection of CompilerError objects to the collection.
        Dim errorsCollection As New CompilerErrorCollection()
        errorsCollection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        errorsCollection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        collection.AddRange(errorsCollection)