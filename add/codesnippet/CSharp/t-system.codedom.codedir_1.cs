            // Creates an empty CodeDirectiveCollection.
            CodeDirectiveCollection collection = new CodeDirectiveCollection();

            // Adds a CodeDirective to the collection.
            collection.Add(new CodeRegionDirective(CodeRegionMode.Start, "Region1"));

            // Adds an array of CodeDirective objects to the collection.
            CodeDirective[] directives = { 
                new CodeRegionDirective(CodeRegionMode.Start,"Region1"), 
                new CodeRegionDirective(CodeRegionMode.End,"Region1") };
            collection.AddRange(directives);

            // Adds a collection of CodeDirective objects to the collection.
            CodeDirectiveCollection directivesCollection = new CodeDirectiveCollection();
            directivesCollection.Add(new CodeRegionDirective(CodeRegionMode.Start, "Region2"));
            directivesCollection.Add(new CodeRegionDirective(CodeRegionMode.End, "Region2"));
            collection.AddRange(directivesCollection);

            // Tests for the presence of a CodeDirective in the 
            // collection, and retrieves its index if it is found.
            CodeDirective testDirective = new CodeRegionDirective(CodeRegionMode.Start, "Region1");
            int itemIndex = -1;
            if (collection.Contains(testDirective))
                itemIndex = collection.IndexOf(testDirective);

            // Copies the contents of the collection beginning at index 0 to the specified CodeDirective array.
            // 'directives' is a CodeDirective array.
            collection.CopyTo(directives, 0);

            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;

            // Inserts a CodeDirective at index 0 of the collection.
            collection.Insert(0, new CodeRegionDirective(CodeRegionMode.Start, "Region1"));

            // Removes the specified CodeDirective from the collection.
            CodeDirective directive = new CodeRegionDirective(CodeRegionMode.Start, "Region1");
            collection.Remove(directive);

            // Removes the CodeDirective at index 0.
            collection.RemoveAt(0);