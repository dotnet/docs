        ' Copies the contents of the collection beginning at index 0 to the specified CodeStatement array.
        ' 'statements' is a CodeStatement array.
        Dim statementArray(collection.Count) As CodeStatement
        collection.CopyTo(statementArray, 0)