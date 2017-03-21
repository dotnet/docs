        ' Tests for the presence of a CodeParameterDeclarationExpression 
        ' in the collection, and retrieves its index if it is found.
        Dim testParameter As New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument")
        Dim itemIndex As Integer = -1
        If collection.Contains(testParameter) Then
            itemIndex = collection.IndexOf(testParameter)
        End If