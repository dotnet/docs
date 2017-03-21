         // Tests for the presence of a CodeCommentStatement in the 
         // collection, and retrieves its index if it is found.
         CodeCommentStatement^ testComment = gcnew CodeCommentStatement( "Test comment" );
         int itemIndex = -1;
         if ( collection->Contains( testComment ) )
            itemIndex = collection->IndexOf( testComment );