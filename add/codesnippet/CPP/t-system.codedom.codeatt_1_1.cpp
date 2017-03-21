         // Creates an empty CodeAttributeArgumentCollection.
         CodeAttributeArgumentCollection^ collection = gcnew CodeAttributeArgumentCollection;

         // Adds a CodeAttributeArgument to the collection.
         collection->Add( gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) ) );

         // Adds an array of CodeAttributeArgument objects to the collection.
         array<CodeAttributeArgument^>^arguments = {gcnew CodeAttributeArgument,gcnew CodeAttributeArgument};
         collection->AddRange( arguments );
         
         // Adds a collection of CodeAttributeArgument objects to 
         // the collection.
         CodeAttributeArgumentCollection^ argumentsCollection = gcnew CodeAttributeArgumentCollection;
         argumentsCollection->Add( gcnew CodeAttributeArgument( "TestBooleanArgument",gcnew CodePrimitiveExpression( true ) ) );
         argumentsCollection->Add( gcnew CodeAttributeArgument( "TestIntArgument",gcnew CodePrimitiveExpression( 1 ) ) );
         collection->AddRange( argumentsCollection );

         // Tests for the presence of a CodeAttributeArgument 
         // within the collection, and retrieves its index if it is found.
         CodeAttributeArgument^ testArgument = gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) );
         int itemIndex = -1;
         if ( collection->Contains( testArgument ) )
            itemIndex = collection->IndexOf( testArgument );

         // Copies the contents of the collection beginning at index 0,
         // to the specified CodeAttributeArgument array.
         // 'arguments' is a CodeAttributeArgument array.
         collection->CopyTo( arguments, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeAttributeArgument at index 0 of the collection.
         collection->Insert( 0, gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) ) );

         // Removes the specified CodeAttributeArgument from the collection.
         CodeAttributeArgument^ argument = gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) );
         collection->Remove( argument );

         // Removes the CodeAttributeArgument at index 0.
         collection->RemoveAt( 0 );