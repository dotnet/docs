         // Creates an empty CodeNamespaceImportCollection.
         CodeNamespaceImportCollection^ collection =
            gcnew CodeNamespaceImportCollection;

         // Adds a CodeNamespaceImport to the collection.
         collection->Add( gcnew CodeNamespaceImport( "System" ) );

         // Adds an array of CodeNamespaceImport objects to the collection.
         array<CodeNamespaceImport^>^ Imports = {
            gcnew CodeNamespaceImport( "System" ),
            gcnew CodeNamespaceImport( "System.Drawing" )};
         collection->AddRange( Imports );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;