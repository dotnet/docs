        ' You can assign the function to the Sub delegate:
        Dim d17 As Del3 = AddressOf doubler

        ' You can then call d17 like a regular Sub procedure.
        d17(5)

        ' You cannot call d17 as a function. It is a Sub, and has no 
        ' return value.
        ' Not valid.
        'Console.WriteLine(d17(5))