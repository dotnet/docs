        ' Creates an empty CodeCatchClauseCollection.
        Dim collection As New CodeCatchClauseCollection()

        ' Adds a CodeCatchClause to the collection.
        collection.Add(New CodeCatchClause("e"))

        ' Adds an array of CodeCatchClause objects to the collection.
        Dim clauses As CodeCatchClause() = {New CodeCatchClause(), New CodeCatchClause()}
        collection.AddRange(clauses)

        ' Adds a collection of CodeCatchClause objects to the collection.
        Dim clausesCollection As New CodeCatchClauseCollection()
        clausesCollection.Add(New CodeCatchClause("e", New CodeTypeReference(GetType(System.ArgumentOutOfRangeException))))
        clausesCollection.Add(New CodeCatchClause("e"))
        collection.AddRange(clausesCollection)

        ' Tests for the presence of a CodeCatchClause in the 
        ' collection, and retrieves its index if it is found.
        Dim testClause As New CodeCatchClause("e")
        Dim itemIndex As Integer = -1
        If collection.Contains(testClause) Then
            itemIndex = collection.IndexOf(testClause)
        End If

        ' Copies the contents of the collection beginning at index 0 to the specified CodeCatchClause array.
        ' 'clauses' is a CodeCatchClause array.
        collection.CopyTo(clauses, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeCatchClause at index 0 of the collection.
        collection.Insert(0, New CodeCatchClause("e"))

        ' Removes the specified CodeCatchClause from the collection.
        Dim clause As New CodeCatchClause("e")
        collection.Remove(clause)

        ' Removes the CodeCatchClause at index 0.
        collection.RemoveAt(0)