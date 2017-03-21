    // Insert a ParserError at index 0 of the collection.
    ParserError error = new ParserError("Error", "Path", 1);
    collection.Insert(0, error);

    // Remove the specified ParserError from the collection.
    collection.Remove(error);