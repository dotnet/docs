         // Creates an empty CodeAttributeDeclarationCollection.
         CodeAttributeDeclarationCollection^ collection = gcnew CodeAttributeDeclarationCollection;

         // Adds a CodeAttributeDeclaration to the collection.
         array<CodeAttributeArgument^>^temp = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         collection->Add( gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp ) );

         // Adds an array of CodeAttributeDeclaration objects 
         // to the collection.
         array<CodeAttributeDeclaration^>^declarations = {gcnew CodeAttributeDeclaration,gcnew CodeAttributeDeclaration};
         collection->AddRange( declarations );

         // Adds a collection of CodeAttributeDeclaration objects 
         // to the collection.
         CodeAttributeDeclarationCollection^ declarationsCollection = gcnew CodeAttributeDeclarationCollection;
         array<CodeAttributeArgument^>^temp1 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         declarationsCollection->Add( gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp1 ) );
         array<CodeAttributeArgument^>^temp2 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( true ) )};
         declarationsCollection->Add( gcnew CodeAttributeDeclaration( "BrowsableAttribute",temp2 ) );
         collection->AddRange( declarationsCollection );

         // Tests for the presence of a CodeAttributeDeclaration in 
         // the collection, and retrieves its index if it is found.
         array<CodeAttributeArgument^>^temp3 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         CodeAttributeDeclaration^ testdeclaration = gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp3 );
         int itemIndex = -1;
         if ( collection->Contains( testdeclaration ) )
            itemIndex = collection->IndexOf( testdeclaration );

         // Copies the contents of the collection, beginning at index 0,
         // to the specified CodeAttributeDeclaration array.
         // 'declarations' is a CodeAttributeDeclaration array.
         collection->CopyTo( declarations, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeAttributeDeclaration at index 0 of the collection.
         array<CodeAttributeArgument^>^temp4 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         collection->Insert( 0, gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp4 ) );

         // Removes the specified CodeAttributeDeclaration from 
         // the collection.
         array<CodeAttributeArgument^>^temp5 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         CodeAttributeDeclaration^ declaration = gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp5 );
         collection->Remove( declaration );

         // Removes the CodeAttributeDeclaration at index 0.
         collection->RemoveAt( 0 );