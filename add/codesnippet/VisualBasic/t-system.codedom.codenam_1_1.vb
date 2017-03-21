        ' Creates an empty CodeNamespaceImportCollection.
        Dim collection As New CodeNamespaceImportCollection()

        ' Adds a CodeNamespaceImport to the collection.
        collection.Add(New CodeNamespaceImport("System"))

        ' Adds an array of CodeNamespaceImport objects to the collection.
        Dim [Imports] As CodeNamespaceImport() = _
            {New CodeNamespaceImport("System"), _
            New CodeNamespaceImport("System.Drawing")}
        collection.AddRange([Imports])

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count