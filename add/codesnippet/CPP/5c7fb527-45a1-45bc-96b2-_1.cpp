         // Adds an array of CodeTypeDeclaration objects to the collection.
         array<CodeTypeDeclaration^>^declarations = {gcnew CodeTypeDeclaration( "TestType1" ),gcnew CodeTypeDeclaration( "TestType2" )};
         collection->AddRange( declarations );
         
         // Adds a collection of CodeTypeDeclaration objects to the 
         // collection.
         CodeTypeDeclarationCollection^ declarationsCollection = gcnew CodeTypeDeclarationCollection;
         declarationsCollection->Add( gcnew CodeTypeDeclaration( "TestType1" ) );
         declarationsCollection->Add( gcnew CodeTypeDeclaration( "TestType2" ) );
         collection->AddRange( declarationsCollection );