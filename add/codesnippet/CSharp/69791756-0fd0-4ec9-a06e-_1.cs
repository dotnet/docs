            // Adds an array of CodeNamespace objects to the collection.
            CodeNamespace[] namespaces = { new CodeNamespace("TestNamespace1"), new CodeNamespace("TestNamespace2") };
            collection.AddRange( namespaces );

            // Adds a collection of CodeNamespace objects to the collection.
            CodeNamespaceCollection namespacesCollection = new CodeNamespaceCollection();
            namespacesCollection.Add( new CodeNamespace("TestNamespace1") );
            namespacesCollection.Add( new CodeNamespace("TestNamespace2") );
            collection.AddRange( namespacesCollection );