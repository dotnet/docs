            // Tests for the presence of a CodeNamespace in the collection,
            // and retrieves its index if it is found.
            CodeNamespace testNamespace = new CodeNamespace("TestNamespace");
            int itemIndex = -1;
            if( collection.Contains( testNamespace ) )
                itemIndex = collection.IndexOf( testNamespace );