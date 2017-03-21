         // Removes the specified CodeAttributeDeclaration from 
         // the collection.
         array<CodeAttributeArgument^>^temp5 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         CodeAttributeDeclaration^ declaration = gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp5 );
         collection->Remove( declaration );