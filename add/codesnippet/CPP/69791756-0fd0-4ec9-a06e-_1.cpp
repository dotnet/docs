         // Adds an array of CodeNamespace objects to the collection.
         array<CodeNamespace^>^namespaces = {gcnew CodeNamespace( "TestNamespace1" ),gcnew CodeNamespace( "TestNamespace2" )};
         collection->AddRange( namespaces );

         // Adds a collection of CodeNamespace objects to the collection.
         CodeNamespaceCollection^ namespacesCollection = gcnew CodeNamespaceCollection;
         namespacesCollection->Add( gcnew CodeNamespace( "TestNamespace1" ) );
         namespacesCollection->Add( gcnew CodeNamespace( "TestNamespace2" ) );
         collection->AddRange( namespacesCollection );