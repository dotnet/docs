         // Adds an array of CodeAttributeArgument objects to the collection.
         array<CodeAttributeArgument^>^arguments = {gcnew CodeAttributeArgument,gcnew CodeAttributeArgument};
         collection->AddRange( arguments );
         
         // Adds a collection of CodeAttributeArgument objects to 
         // the collection.
         CodeAttributeArgumentCollection^ argumentsCollection = gcnew CodeAttributeArgumentCollection;
         argumentsCollection->Add( gcnew CodeAttributeArgument( "TestBooleanArgument",gcnew CodePrimitiveExpression( true ) ) );
         argumentsCollection->Add( gcnew CodeAttributeArgument( "TestIntArgument",gcnew CodePrimitiveExpression( 1 ) ) );
         collection->AddRange( argumentsCollection );