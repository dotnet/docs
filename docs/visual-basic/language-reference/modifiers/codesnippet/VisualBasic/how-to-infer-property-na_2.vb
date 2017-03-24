        Dim productName As String = "paperclips"
        Dim productPrice As Double = 1.29
        Dim anonProduct = New With {Key productName, Key productPrice}

        ' To create uppercase variable names for the new properties,
        ' assign variables productName and productPrice to uppercase identifiers.
        Dim anonProduct1 = New With {Key .Name = productName, Key .Price = productPrice}