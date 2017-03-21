    ' Insert a ParserError at index 0 of the collection.
    Dim [error] As New ParserError("Error", "Path", 1)
    collection.Insert(0, [error])

    ' Remove the specified ParserError from the collection.
    collection.Remove([error])