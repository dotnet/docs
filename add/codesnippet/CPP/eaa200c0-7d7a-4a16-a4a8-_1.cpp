         // Tests for the presence of a CodeCatchClause in the 
         // collection, and retrieves its index if it is found.
         CodeCatchClause^ testClause = gcnew CodeCatchClause( "e" );
         int itemIndex = -1;
         if ( collection->Contains( testClause ) )
            itemIndex = collection->IndexOf( testClause );