        ' Adds an array of CodeDirective objects to the collection.
        Dim directives As CodeDirective() = {New CodeRegionDirective(CodeRegionMode.Start, "Region1"), New CodeRegionDirective(CodeRegionMode.End, "Region1")}
        collection.AddRange(directives)

        ' Adds a collection of CodeDirective objects to the collection.
        Dim directivesCollection As New CodeDirectiveCollection()
        directivesCollection.Add(New CodeRegionDirective(CodeRegionMode.Start, "Region2"))
        directivesCollection.Add(New CodeRegionDirective(CodeRegionMode.End, "Region2"))
        collection.AddRange(directivesCollection)