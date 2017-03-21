         // Adds an array of CodeExpression objects to the collection.
         array<CodeExpression^>^expressions = {gcnew CodePrimitiveExpression( true ),gcnew CodePrimitiveExpression( true )};
         collection->AddRange( expressions );
         
         // Adds a collection of CodeExpression objects to the collection.
         CodeExpressionCollection^ expressionsCollection = gcnew CodeExpressionCollection;
         expressionsCollection->Add( gcnew CodePrimitiveExpression( true ) );
         expressionsCollection->Add( gcnew CodePrimitiveExpression( true ) );
         collection->AddRange( expressionsCollection );