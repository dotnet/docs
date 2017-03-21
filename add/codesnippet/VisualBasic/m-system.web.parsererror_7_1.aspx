    ' Add an array of ParserError objects to the collection.
    Dim errors As ParserError() = _
        {New ParserError("Error 2", "Path", 1), _
        New ParserError("Error 3", "Path", 1)}
    collection.AddRange(errors)

    ' Ads a collection of ParserError objects to the collection.
    Dim errorsCollection As New ParserErrorCollection()
    errorsCollection.Add(New ParserError("Error", "Path", 1))
    errorsCollection.Add(New ParserError("Error", "Path", 1))
    collection.AddRange(errorsCollection)