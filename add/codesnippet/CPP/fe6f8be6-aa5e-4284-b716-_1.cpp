         // Removes the specified CodeAttributeArgument from the collection.
         CodeAttributeArgument^ argument = gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) );
         collection->Remove( argument );