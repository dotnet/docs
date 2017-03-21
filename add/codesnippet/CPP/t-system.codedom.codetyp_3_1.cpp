         // Creates an empty CodeTypeDeclarationCollection.
         CodeTypeDeclarationCollection^ collection = gcnew CodeTypeDeclarationCollection;

         // Adds a CodeTypeDeclaration to the collection.
         collection->Add( gcnew CodeTypeDeclaration( "TestType" ) );

         // Adds an array of CodeTypeDeclaration objects to the collection.
         array<CodeTypeDeclaration^>^declarations = {gcnew CodeTypeDeclaration( "TestType1" ),gcnew CodeTypeDeclaration( "TestType2" )};
         collection->AddRange( declarations );
         
         // Adds a collection of CodeTypeDeclaration objects to the 
         // collection.
         CodeTypeDeclarationCollection^ declarationsCollection = gcnew CodeTypeDeclarationCollection;
         declarationsCollection->Add( gcnew CodeTypeDeclaration( "TestType1" ) );
         declarationsCollection->Add( gcnew CodeTypeDeclaration( "TestType2" ) );
         collection->AddRange( declarationsCollection );

         // Tests for the presence of a CodeTypeDeclaration in the 
         // collection, and retrieves its index if it is found.
         CodeTypeDeclaration^ testDeclaration = gcnew CodeTypeDeclaration( "TestType" );
         int itemIndex = -1;
         if ( collection->Contains( testDeclaration ) )
            itemIndex = collection->IndexOf( testDeclaration );

         // Copies the contents of the collection, beginning at index 0,
         // to the specified CodeTypeDeclaration array.
         // 'declarations' is a CodeTypeDeclaration array.
         collection->CopyTo( declarations, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeTypeDeclaration at index 0 of the collection.
         collection->Insert( 0, gcnew CodeTypeDeclaration( "TestType" ) );

         // Removes the specified CodeTypeDeclaration from the collection.
         CodeTypeDeclaration^ declaration = gcnew CodeTypeDeclaration( "TestType" );
         collection->Remove( declaration );

         // Removes the CodeTypeDeclaration at index 0.
         collection->RemoveAt( 0 );