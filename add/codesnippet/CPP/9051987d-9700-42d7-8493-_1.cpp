         // Adds a CodeAttributeDeclaration to the collection.
         array<CodeAttributeArgument^>^temp = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         collection->Add( gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp ) );