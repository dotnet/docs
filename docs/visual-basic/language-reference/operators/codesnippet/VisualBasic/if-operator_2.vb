        number = 12

        ' When the divisor is not 0, both If and IIf return 4.
        Dim divisor = 3
        Console.WriteLine(If(divisor <> 0, number \ divisor, 0))
        Console.WriteLine(IIf(divisor <> 0, number \ divisor, 0))

        ' When the divisor is 0, IIf causes a run-time error, but If does not.
        divisor = 0
        Console.WriteLine(If(divisor <> 0, number \ divisor, 0))
        ' Console.WriteLine(IIf(divisor <> 0, number \ divisor, 0))