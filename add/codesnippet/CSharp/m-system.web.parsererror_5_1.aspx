    // Test for the presence of a ParserError in the 
    // collection, and retrieve its index if it is found.
    ParserError testError = new ParserError("Error", "Path", 1);
    int itemIndex = -1;
    if (collection.Contains(testError))
      itemIndex = collection.IndexOf(testError);