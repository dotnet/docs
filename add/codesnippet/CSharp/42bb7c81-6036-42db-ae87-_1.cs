            // Adds an array of CodeCatchClause objects to the collection.
            CodeCatchClause[] clauses = { new CodeCatchClause(), new CodeCatchClause() };
            collection.AddRange( clauses );

            // Adds a collection of CodeCatchClause objects to the collection.
            CodeCatchClauseCollection clausesCollection = new CodeCatchClauseCollection();
            clausesCollection.Add( new CodeCatchClause("e", new CodeTypeReference(typeof(System.ArgumentOutOfRangeException))) );
            clausesCollection.Add( new CodeCatchClause("e") );
            collection.AddRange( clausesCollection );