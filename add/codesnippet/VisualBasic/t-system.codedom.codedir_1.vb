        ' Creates an empty CodeDirectiveCollection.
        Dim collection As New CodeDirectiveCollection()
        ' Adds a CodeDirective to the collection.
        collection.Add(New CodeRegionDirective(CodeRegionMode.Start, "Region1"))
        ' Adds an array of CodeDirective objects to the collection.
        Dim directives As CodeDirective() = {New CodeRegionDirective(CodeRegionMode.Start, "Region1"), New CodeRegionDirective(CodeRegionMode.End, "Region1")}
        collection.AddRange(directives)

        ' Adds a collection of CodeDirective objects to the collection.
        Dim directivesCollection As New CodeDirectiveCollection()
        directivesCollection.Add(New CodeRegionDirective(CodeRegionMode.Start, "Region2"))
        directivesCollection.Add(New CodeRegionDirective(CodeRegionMode.End, "Region2"))
        collection.AddRange(directivesCollection)
        ' Tests for the presence of a CodeDirective in the 
        ' collection, and retrieves its index if it is found.
        Dim testDirective = New CodeRegionDirective(CodeRegionMode.Start, "Region1")
        Dim itemIndex As Integer = -1
        If collection.Contains(testDirective) Then
            itemIndex = collection.IndexOf(testDirective)
        End If
        ' Copies the contents of the collection beginning at index 0 to the specified CodeDirective array.
        ' 'directives' is a CodeDirective array.
        collection.CopyTo(directives, 0)
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        ' Inserts a CodeDirective at index 0 of the collection.
        collection.Insert(0, New CodeRegionDirective(CodeRegionMode.Start, "Region1"))
        ' Removes the specified CodeDirective from the collection.
        Dim directive = New CodeRegionDirective(CodeRegionMode.Start, "Region1")
        collection.Remove(directive)
        ' Removes the CodeDirective at index 0.
        collection.RemoveAt(0)
    
    End Sub 'CodeDirectiveCollectionExample 
End Class 'Class1 