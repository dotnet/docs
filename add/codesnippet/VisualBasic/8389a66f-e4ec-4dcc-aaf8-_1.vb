        ' Adds an array of CodeAttributeArgument objects to the collection.
        Dim arguments As CodeAttributeArgument() = {New CodeAttributeArgument(), New CodeAttributeArgument()}
        collection.AddRange(arguments)

        ' Adds a collection of CodeAttributeArgument objects to the collection.
        Dim argumentsCollection As New CodeAttributeArgumentCollection()
        argumentsCollection.Add(New CodeAttributeArgument("TestBooleanArgument", New CodePrimitiveExpression(True)))
        argumentsCollection.Add(New CodeAttributeArgument("TestIntArgument", New CodePrimitiveExpression(1)))
        collection.AddRange(argumentsCollection)