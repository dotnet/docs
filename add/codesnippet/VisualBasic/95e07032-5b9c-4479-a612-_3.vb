        ' Get the products from the both arrays
        ' excluding duplicates.

        Dim union = store1.Union(store2, New ProductComparer())

        For Each product In union
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' apple 9
        ' orange 4
        ' lemon 12
        ' 