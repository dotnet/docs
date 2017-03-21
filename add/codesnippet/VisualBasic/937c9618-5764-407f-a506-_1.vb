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