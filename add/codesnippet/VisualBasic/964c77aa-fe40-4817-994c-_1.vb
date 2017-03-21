        ' Adds an array of CodeExpression objects to the collection.
        Dim expressions As CodeExpression() = {New CodePrimitiveExpression(True), New CodePrimitiveExpression(True)}
        collection.AddRange(expressions)

        ' Adds a collection of CodeExpression objects to the collection.
        Dim expressionsCollection As New CodeExpressionCollection()
        expressionsCollection.Add(New CodePrimitiveExpression(True))
        expressionsCollection.Add(New CodePrimitiveExpression(True))
        collection.AddRange(expressionsCollection)