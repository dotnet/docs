
        Dim products() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}, 
             New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "lemon", .Code = 12}}

        ' Exclude duplicates.

        Dim noduplicates = products.Distinct()

        For Each product In noduplicates
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' apple 9
        ' orange 4
        ' lemon 12
        ' 