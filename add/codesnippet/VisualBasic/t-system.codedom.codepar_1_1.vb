        ' Creates an empty CodeParameterDeclarationExpressionCollection.
        Dim collection As New CodeParameterDeclarationExpressionCollection()

        ' Adds a CodeParameterDeclarationExpression to the collection.
        collection.Add(New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"))

        ' Adds an array of CodeParameterDeclarationExpression objects 
        ' to the collection.
        Dim parameters As CodeParameterDeclarationExpression() = {New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"), New CodeParameterDeclarationExpression(GetType(Boolean), "testBoolArgument")}
        collection.AddRange(parameters)

        ' Adds a collection of CodeParameterDeclarationExpression 
        ' objects to the collection.
        Dim parametersCollection As New CodeParameterDeclarationExpressionCollection()
        parametersCollection.Add(New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"))
        parametersCollection.Add(New CodeParameterDeclarationExpression(GetType(Boolean), "testBoolArgument"))
        collection.AddRange(parametersCollection)

        ' Tests for the presence of a CodeParameterDeclarationExpression 
        ' in the collection, and retrieves its index if it is found.
        Dim testParameter As New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument")
        Dim itemIndex As Integer = -1
        If collection.Contains(testParameter) Then
            itemIndex = collection.IndexOf(testParameter)
        End If

        ' Copies the contents of the collection beginning at index 0 to the specified CodeParameterDeclarationExpression array.
        ' 'parameters' is a CodeParameterDeclarationExpression array.
        collection.CopyTo(parameters, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeParameterDeclarationExpression at index 0 
        ' of the collection.
        collection.Insert(0, New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"))

        ' Removes the specified CodeParameterDeclarationExpression 
        ' from the collection.
        Dim parameter As New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument")
        collection.Remove(parameter)

        ' Removes the CodeParameterDeclarationExpression at index 0.
        collection.RemoveAt(0)