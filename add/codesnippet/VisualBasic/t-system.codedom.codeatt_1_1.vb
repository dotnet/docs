        ' Creates an empty CodeAttributeArgumentCollection.
        Dim collection As New CodeAttributeArgumentCollection()

        ' Adds a CodeAttributeArgument to the collection.
        collection.Add(New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True)))

        ' Adds an array of CodeAttributeArgument objects to the collection.
        Dim arguments As CodeAttributeArgument() = {New CodeAttributeArgument(), New CodeAttributeArgument()}
        collection.AddRange(arguments)

        ' Adds a collection of CodeAttributeArgument objects to the collection.
        Dim argumentsCollection As New CodeAttributeArgumentCollection()
        argumentsCollection.Add(New CodeAttributeArgument("TestBooleanArgument", New CodePrimitiveExpression(True)))
        argumentsCollection.Add(New CodeAttributeArgument("TestIntArgument", New CodePrimitiveExpression(1)))
        collection.AddRange(argumentsCollection)

        ' Tests for the presence of a CodeAttributeArgument in 
        ' the collection, and retrieves its index if it is found.
        Dim testArgument As New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True))
        Dim itemIndex As Integer = -1
        If collection.Contains(testArgument) Then
            itemIndex = collection.IndexOf(testArgument)
        End If

        ' Copies the contents of the collection beginning at index 0,
        ' to the specified CodeAttributeArgument array.
        ' 'arguments' is a CodeAttributeArgument array.
        collection.CopyTo(arguments, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeAttributeArgument at index 0 of the collection.
        collection.Insert(0, New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True)))

        ' Removes the specified CodeAttributeArgument from the collection.
        Dim argument As New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True))
        collection.Remove(argument)

        ' Removes the CodeAttributeArgument at index 0.
        collection.RemoveAt(0)