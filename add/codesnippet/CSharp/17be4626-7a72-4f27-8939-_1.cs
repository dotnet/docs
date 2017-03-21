            // Adds an array of CodeStatement objects to the collection.
            CodeStatement[] statements = { 
                            new CodeCommentStatement("Test comment statement"), 
                            new CodeCommentStatement("Test comment statement")};
            collection.AddRange( statements );

            // Adds a collection of CodeStatement objects to the collection.
            CodeStatement testStatement = new CodeCommentStatement("Test comment statement");
            CodeStatementCollection statementsCollection = new CodeStatementCollection();
            statementsCollection.Add( new CodeCommentStatement("Test comment statement") );
            statementsCollection.Add( new CodeCommentStatement("Test comment statement") );
            statementsCollection.Add( testStatement );

            collection.AddRange( statementsCollection );