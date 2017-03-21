        ' Get the products from the first array 
        ' that have duplicates in the second array.

        Dim duplicates = store1.Intersect(store2)

        For Each product In duplicates
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' apple 9
        ' 