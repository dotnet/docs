        ' Adds an array of CodeNamespaceImport objects to the collection.
        Dim [Imports] As CodeNamespaceImport() = _
            {New CodeNamespaceImport("System"), _
            New CodeNamespaceImport("System.Drawing")}
        collection.AddRange([Imports])