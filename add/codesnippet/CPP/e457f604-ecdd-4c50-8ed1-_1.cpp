         // Inserts a CodeAttributeDeclaration at index 0 of the collection.
         array<CodeAttributeArgument^>^temp4 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         collection->Insert( 0, gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp4 ) );