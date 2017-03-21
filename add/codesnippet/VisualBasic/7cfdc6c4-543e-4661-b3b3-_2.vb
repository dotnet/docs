
        Dim fruits() As Product = 
           {New Product With {.Name = "apple", .Code = 9}, 
            New Product With {.Name = "orange", .Code = 4}, 
            New Product With {.Name = "lemon", .Code = 12}}

        Dim apple = New Product With {.Name = "apple", .Code = 9}
        Dim kiwi = New Product With {.Name = "kiwi", .Code = 8}

        Dim prodc As New ProductComparer()

        Dim hasApple = fruits.Contains(apple, prodc)
        Dim hasKiwi = fruits.Contains(kiwi, prodc)

        Console.WriteLine("Apple? " & hasApple)
        Console.WriteLine("Kiwi? " & hasKiwi)


        ' This code produces the following output:
        '
        ' Apple? True
        ' Kiwi? False