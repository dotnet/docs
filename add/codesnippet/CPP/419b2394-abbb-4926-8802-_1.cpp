         // Tests for the presence of a CodeTypeDeclaration in the 
         // collection, and retrieves its index if it is found.
         CodeTypeDeclaration^ testDeclaration = gcnew CodeTypeDeclaration( "TestType" );
         int itemIndex = -1;
         if ( collection->Contains( testDeclaration ) )
            itemIndex = collection->IndexOf( testDeclaration );