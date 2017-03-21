        ' Removes the specified CodeParameterDeclarationExpression 
        ' from the collection.
        Dim parameter As New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument")
        collection.Remove(parameter)