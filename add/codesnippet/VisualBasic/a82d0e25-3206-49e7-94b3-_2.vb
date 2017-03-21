        Dim fruits1() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}, 
             New Product With {.Name = "lemon", .Code = 12}}

        Dim fruits2() As Product = 
            {New Product With {.Name = "apple", .Code = 9}}

        ' Get all the elements from the first array
        ' except for the elements from the second array.

        Dim except = fruits1.Except(fruits2, New ProductComparer())

        For Each product In except
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' orange 4
        ' lemon 12
