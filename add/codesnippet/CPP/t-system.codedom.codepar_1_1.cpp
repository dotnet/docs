         // Creates an empty CodeParameterDeclarationExpressionCollection.
         CodeParameterDeclarationExpressionCollection^ collection = gcnew CodeParameterDeclarationExpressionCollection;

         // Adds a CodeParameterDeclarationExpression to the collection.
         collection->Add( gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" ) );

         // Adds an array of CodeParameterDeclarationExpression objects 
         // to the collection.
         array<CodeParameterDeclarationExpression^>^parameters = {gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" ),gcnew CodeParameterDeclarationExpression( bool::typeid,"testBoolArgument" )};
         collection->AddRange( parameters );
         
         // Adds a collection of CodeParameterDeclarationExpression objects 
         // to the collection.
         CodeParameterDeclarationExpressionCollection^ parametersCollection = gcnew CodeParameterDeclarationExpressionCollection;
         parametersCollection->Add( gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" ) );
         parametersCollection->Add( gcnew CodeParameterDeclarationExpression( bool::typeid,"testBoolArgument" ) );
         collection->AddRange( parametersCollection );

         // Tests for the presence of a CodeParameterDeclarationExpression 
         // in the collection, and retrieves its index if it is found.
         CodeParameterDeclarationExpression^ testParameter = gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" );
         int itemIndex = -1;
         if ( collection->Contains( testParameter ) )
            itemIndex = collection->IndexOf( testParameter );

         // Copies the contents of the collection beginning at index 0 to the specified CodeParameterDeclarationExpression array.
         // 'parameters' is a CodeParameterDeclarationExpression array.
         collection->CopyTo( parameters, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeParameterDeclarationExpression at index 0 
         // of the collection.
         collection->Insert( 0, gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" ) );

         // Removes the specified CodeParameterDeclarationExpression 
         // from the collection.
         CodeParameterDeclarationExpression^ parameter = gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" );
         collection->Remove( parameter );

         // Removes the CodeParameterDeclarationExpression at index 0.
         collection->RemoveAt( 0 );