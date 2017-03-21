        ' Adds an array of CodeTypeDeclaration objects to the 
        ' collection.
        Dim declarations As CodeTypeDeclaration() = {New CodeTypeDeclaration("TestType1"), New CodeTypeDeclaration("TestType2")}
        collection.AddRange(declarations)

        ' Adds a collection of CodeTypeDeclaration objects to the collection.
        Dim declarationsCollection As New CodeTypeDeclarationCollection()
        declarationsCollection.Add(New CodeTypeDeclaration("TestType1"))
        declarationsCollection.Add(New CodeTypeDeclaration("TestType2"))
        collection.AddRange(declarationsCollection)