         // Adds an array of CodeTypeReference objects to the collection.
         array<CodeTypeReference^>^references = {gcnew CodeTypeReference( bool::typeid ),gcnew CodeTypeReference( bool::typeid )};
         collection->AddRange( references );
         
         // Adds a collection of CodeTypeReference objects to the collection.
         CodeTypeReferenceCollection^ referencesCollection = gcnew CodeTypeReferenceCollection;
         referencesCollection->Add( gcnew CodeTypeReference( bool::typeid ) );
         referencesCollection->Add( gcnew CodeTypeReference( bool::typeid ) );
         collection->AddRange( referencesCollection );