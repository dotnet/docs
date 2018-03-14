        Dim increment1 = Function(x) x + 1
        Dim increment2 = Function(x)
                             Return x + 2
                         End Function

        ' Write the value 2.
        Console.WriteLine(increment1(1))

        ' Write the value 4.
        Console.WriteLine(increment2(2))