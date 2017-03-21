        ' Creates an empty CodeStatementCollection.
        Dim collection As New CodeStatementCollection

        ' Adds a CodeStatement to the collection.
        collection.Add(New CodeCommentStatement("Test comment statement"))

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

        ' Tests for the presence of a CodeStatement in the 
        ' collection, and retrieves its index if it is found.
        Dim itemIndex As Integer = -1
        If collection.Contains(testStatement) Then
            itemIndex = collection.IndexOf(testStatement)
        End If

        ' Copies the contents of the collection beginning at index 0 to the specified CodeStatement array.
        ' 'statements' is a CodeStatement array.
        Dim statementArray(collection.Count) As CodeStatement
        collection.CopyTo(statementArray, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeStatement at index 0 of the collection.
        collection.Insert(0, New CodeCommentStatement("Test comment statement"))

        ' Removes the specified CodeStatement from the collection.
        collection.Remove(testStatement)

        ' Removes the CodeStatement at index 0.
        collection.RemoveAt(0)