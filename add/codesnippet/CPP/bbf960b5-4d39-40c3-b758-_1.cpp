         // Tests for the presence of a CodeExpression in the 
         // collection, and retrieves its index if it is found.
         CodeExpression^ testComment = gcnew CodePrimitiveExpression( true );
         int itemIndex = -1;
         if ( collection->Contains( testComment ) )
            itemIndex = collection->IndexOf( testComment );