        ' Adds an array of CodeTypeReference objects to the collection.
        Dim references As CodeTypeReference() = {New CodeTypeReference(GetType(Boolean)), New CodeTypeReference(GetType(Boolean))}
        collection.AddRange(references)

        ' Adds a collection of CodeTypeReference objects to the collection.
        Dim referencesCollection As New CodeTypeReferenceCollection()
        referencesCollection.Add(New CodeTypeReference(GetType(Boolean)))
        referencesCollection.Add(New CodeTypeReference(GetType(Boolean)))
        collection.AddRange(referencesCollection)