            // Adds an array of CodeCommentStatement objects to the collection.
            CodeCommentStatement[] comments = { new CodeCommentStatement("Test comment"), new CodeCommentStatement("Another test comment") };
            collection.AddRange( comments );

            // Adds a collection of CodeCommentStatement objects to the collection.
            CodeCommentStatementCollection commentsCollection = new CodeCommentStatementCollection();
            commentsCollection.Add( new CodeCommentStatement("Test comment") );
            commentsCollection.Add( new CodeCommentStatement("Another test comment") );
            collection.AddRange( commentsCollection );