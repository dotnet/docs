        ' Creates an empty CodeExpressionCollection.
        Dim collection As New CodeExpressionCollection()

        ' Adds a CodeExpression to the collection.
        collection.Add(New CodePrimitiveExpression(True))

        ' Adds an array of CodeExpression objects to the collection.
        Dim expressions As CodeExpression() = {New CodePrimitiveExpression(True), New CodePrimitiveExpression(True)}
        collection.AddRange(expressions)

        ' Adds a collection of CodeExpression objects to the collection.
        Dim expressionsCollection As New CodeExpressionCollection()
        expressionsCollection.Add(New CodePrimitiveExpression(True))
        expressionsCollection.Add(New CodePrimitiveExpression(True))
        collection.AddRange(expressionsCollection)

        ' Tests for the presence of a CodeExpression in the 
        ' collection, and retrieves its index if it is found.
        Dim testComment = New CodePrimitiveExpression(True)
        Dim itemIndex As Integer = -1
        If collection.Contains(testComment) Then
            itemIndex = collection.IndexOf(testComment)
        End If

        ' Copies the contents of the collection beginning at index 0 to the specified CodeExpression array.
        ' 'expressions' is a CodeExpression array.
        collection.CopyTo(expressions, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeExpression at index 0 of the collection.
        collection.Insert(0, New CodePrimitiveExpression(True))

        ' Removes the specified CodeExpression from the collection.
        Dim expression = New CodePrimitiveExpression(True)
        collection.Remove(expression)

        ' Removes the CodeExpression at index 0.
        collection.RemoveAt(0)