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