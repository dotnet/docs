        ' The assigned lambda expression specifies no parameters, even though
        ' Del2 has two parameters. Because the assigned function in this 
        ' example is a lambda expression, Option Strict can be on or off.
        ' Compare the declaration of d16, where a standard function is assigned.
        Dim d11 As Del2 = Function() 3

        ' The parameters are still there, however, as defined in the delegate.
        Console.WriteLine(d11(5, "five"))

        ' Not valid.
        ' Console.WriteLine(d11())
        ' Console.WriteLine(d11(5))