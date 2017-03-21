        ' Adds an array of CodeNamespace objects to the collection.
        Dim namespaces As CodeNamespace() = {New CodeNamespace("TestNamespace1"), New CodeNamespace("TestNamespace2")}
        collection.AddRange(namespaces)

        ' Adds a collection of CodeNamespace objects to the collection.
        Dim namespacesCollection As New CodeNamespaceCollection()
        namespacesCollection.Add(New CodeNamespace("TestNamespace1"))
        namespacesCollection.Add(New CodeNamespace("TestNamespace2"))
        collection.AddRange(namespacesCollection)