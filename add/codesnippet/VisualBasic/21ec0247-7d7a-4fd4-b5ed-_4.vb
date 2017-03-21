
        Dim storeA() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}}

        Dim storeB() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}}

        Dim equalAB = storeA.SequenceEqual(storeB)

        Console.WriteLine("Equal? " & equalAB)

        ' This code produces the following output:

        ' Equal? True