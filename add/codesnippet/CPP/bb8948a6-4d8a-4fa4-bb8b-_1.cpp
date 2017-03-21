         // Adds an array of CodeNamespaceImport objects to the collection.
         array<CodeNamespaceImport^>^ Imports = {
            gcnew CodeNamespaceImport( "System" ),
            gcnew CodeNamespaceImport( "System.Drawing" )};
         collection->AddRange( Imports );