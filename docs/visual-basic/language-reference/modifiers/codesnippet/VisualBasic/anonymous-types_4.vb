        ' Variable product1 is an instance of a simple anonymous type.
        Dim product1 = New With {.Name = "paperclips", .Price = 1.29}
        ' -or-
        ' product2 is an instance of an anonymous type with key properties.
        Dim product2 = New With {Key .Name = "paperclips", Key .Price = 1.29}