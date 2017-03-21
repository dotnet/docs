            // Creates an empty CodeCatchClauseCollection.
            CodeCatchClauseCollection collection = new CodeCatchClauseCollection();

            // Adds a CodeCatchClause to the collection.
            collection.Add( new CodeCatchClause("e") );

            // Adds an array of CodeCatchClause objects to the collection.
            CodeCatchClause[] clauses = { new CodeCatchClause(), new CodeCatchClause() };
            collection.AddRange( clauses );

            // Adds a collection of CodeCatchClause objects to the collection.
            CodeCatchClauseCollection clausesCollection = new CodeCatchClauseCollection();
            clausesCollection.Add( new CodeCatchClause("e", new CodeTypeReference(typeof(System.ArgumentOutOfRangeException))) );
            clausesCollection.Add( new CodeCatchClause("e") );
            collection.AddRange( clausesCollection );

            // Tests for the presence of a CodeCatchClause in the 
            // collection, and retrieves its index if it is found.
            CodeCatchClause testClause = new CodeCatchClause("e");
            int itemIndex = -1;
            if( collection.Contains( testClause ) )
                itemIndex = collection.IndexOf( testClause );

            // Copies the contents of the collection beginning at index 0 to the specified CodeCatchClause array.
            // 'clauses' is a CodeCatchClause array.
            collection.CopyTo( clauses, 0 );

            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;

            // Inserts a CodeCatchClause at index 0 of the collection.
            collection.Insert( 0, new CodeCatchClause("e") );

            // Removes the specified CodeCatchClause from the collection.
            CodeCatchClause clause = new CodeCatchClause("e");
            collection.Remove( clause );

            // Removes the CodeCatchClause at index 0.
            collection.RemoveAt(0);