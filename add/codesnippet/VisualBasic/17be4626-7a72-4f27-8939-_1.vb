        ' Adds an array of CodeStatement objects to the collection.
        Dim statements As CodeStatement() = {New CodeCommentStatement("Test comment statement"), New CodeCommentStatement("Test comment statement")}
        collection.AddRange(statements)

        ' Adds a collection of CodeStatement objects to the collection.
        Dim testStatement As New CodeStatement
        Dim statementsCollection As New CodeStatementCollection
        statementsCollection.Add(New CodeCommentStatement("Test comment statement"))
        statementsCollection.Add(New CodeCommentStatement("Test comment statement"))
        statementsCollection.Add(testStatement)
        collection.AddRange(statementsCollection)