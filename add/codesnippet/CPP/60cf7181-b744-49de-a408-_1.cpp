         // Removes the specified CodeParameterDeclarationExpression 
         // from the collection.
         CodeParameterDeclarationExpression^ parameter = gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" );
         collection->Remove( parameter );