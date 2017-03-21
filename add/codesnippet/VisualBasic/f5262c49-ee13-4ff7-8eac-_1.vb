        ' Adds an array of CodeCatchClause objects to the collection.
        Dim clauses As CodeCatchClause() = {New CodeCatchClause(), New CodeCatchClause()}
        collection.AddRange(clauses)

        ' Adds a collection of CodeCatchClause objects to the collection.
        Dim clausesCollection As New CodeCatchClauseCollection()
        clausesCollection.Add(New CodeCatchClause("e", New CodeTypeReference(GetType(System.ArgumentOutOfRangeException))))
        clausesCollection.Add(New CodeCatchClause("e"))
        collection.AddRange(clausesCollection)