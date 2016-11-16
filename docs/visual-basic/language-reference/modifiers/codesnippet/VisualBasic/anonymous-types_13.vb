        ' Declaring instances of a named type.
        Dim firstProd1 As New Product("paperclips", 1.29)
        Dim secondProd1 As New Product("desklamp", 28.99)
        Dim thirdProd1 As New Product("stapler", 5.09)

        ' Declaring instances of an anonymous type.
        Dim firstProd2 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        Dim secondProd2 = New With {Key .Name = "desklamp", Key .Price = 28.99}
        Dim thirdProd2 = New With {Key .Name = "stapler", Key .Price = 5.09}