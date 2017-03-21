        ' Removes the specified CodeAttributeArgument from the collection.
        Dim argument As New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True))
        collection.Remove(argument)