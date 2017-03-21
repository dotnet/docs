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