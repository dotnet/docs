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