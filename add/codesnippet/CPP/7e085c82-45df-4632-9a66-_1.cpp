         // Tests for the presence of a CodeAttributeDeclaration in 
         // the collection, and retrieves its index if it is found.
         array<CodeAttributeArgument^>^temp3 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         CodeAttributeDeclaration^ testdeclaration = gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp3 );
         int itemIndex = -1;
         if ( collection->Contains( testdeclaration ) )
            itemIndex = collection->IndexOf( testdeclaration );