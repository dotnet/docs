         // Tests for the presence of a CodeParameterDeclarationExpression 
         // in the collection, and retrieves its index if it is found.
         CodeParameterDeclarationExpression^ testParameter = gcnew CodeParameterDeclarationExpression( int::typeid,"testIntArgument" );
         int itemIndex = -1;
         if ( collection->Contains( testParameter ) )
            itemIndex = collection->IndexOf( testParameter );