         // Tests for the presence of a CodeAttributeArgument 
         // within the collection, and retrieves its index if it is found.
         CodeAttributeArgument^ testArgument = gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) );
         int itemIndex = -1;
         if ( collection->Contains( testArgument ) )
            itemIndex = collection->IndexOf( testArgument );