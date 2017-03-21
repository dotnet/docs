        ' Creates an empty CodeTypeReferenceCollection.
        Dim collection As New CodeTypeReferenceCollection()

        ' Adds a CodeTypeReference to the collection.
        collection.Add(New CodeTypeReference(GetType(Boolean)))

        ' Adds an array of CodeTypeReference objects to the collection.
        Dim references As CodeTypeReference() = {New CodeTypeReference(GetType(Boolean)), New CodeTypeReference(GetType(Boolean))}
        collection.AddRange(references)

        ' Adds a collection of CodeTypeReference objects to the collection.
        Dim referencesCollection As New CodeTypeReferenceCollection()
        referencesCollection.Add(New CodeTypeReference(GetType(Boolean)))
        referencesCollection.Add(New CodeTypeReference(GetType(Boolean)))
        collection.AddRange(referencesCollection)

        ' Tests for the presence of a CodeTypeReference in the 
        ' collection, and retrieves its index if it is found.
        Dim testReference As New CodeTypeReference(GetType(Boolean))
        Dim itemIndex As Integer = -1
        If collection.Contains(testReference) Then
            itemIndex = collection.IndexOf(testReference)
        End If

        ' Copies the contents of the collection, beginning at index 0, 
        ' to the specified CodeTypeReference array.
        ' 'references' is a CodeTypeReference array.
        collection.CopyTo(references, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeTypeReference at index 0 of the collection.
        collection.Insert(0, New CodeTypeReference(GetType(Boolean)))

        ' Removes the specified CodeTypeReference from the collection.
        Dim reference As New CodeTypeReference(GetType(Boolean))
        collection.Remove(reference)

        ' Removes the CodeTypeReference at index 0.
        collection.RemoveAt(0)