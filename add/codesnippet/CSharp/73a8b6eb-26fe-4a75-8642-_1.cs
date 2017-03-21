            // Tests for the presence of a CodeTypeReference in the 
            // collection, and retrieves its index if it is found.
            CodeTypeReference testReference = new CodeTypeReference(typeof(bool));
            int itemIndex = -1;
            if( collection.Contains( testReference ) )
                itemIndex = collection.IndexOf( testReference );