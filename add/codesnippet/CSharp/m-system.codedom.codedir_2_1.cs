            // Tests for the presence of a CodeDirective in the 
            // collection, and retrieves its index if it is found.
            CodeDirective testDirective = new CodeRegionDirective(CodeRegionMode.Start, "Region1");
            int itemIndex = -1;
            if (collection.Contains(testDirective))
                itemIndex = collection.IndexOf(testDirective);