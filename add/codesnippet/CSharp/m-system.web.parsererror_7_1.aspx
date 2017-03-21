    // Add an array of ParserError objects to the collection.
    ParserError[] errors = 
        { new ParserError("Error 2", "Path", 1), 
        new ParserError("Error 3", "Path", 1) };
    collection.AddRange(errors);

    // Add a collection of ParserError objects to the collection.
    ParserErrorCollection errorsCollection = new ParserErrorCollection();
    errorsCollection.Add(new ParserError("Error", "Path", 1));
    errorsCollection.Add(new ParserError("Error", "Path", 1));
    collection.AddRange(errorsCollection);