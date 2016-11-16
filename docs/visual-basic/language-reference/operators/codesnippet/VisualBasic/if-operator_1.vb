        ' This statement prints TruePart, because the first argument is true.
        Console.WriteLine(If(True, "TruePart", "FalsePart"))

        ' This statement prints FalsePart, because the first argument is false.
        Console.WriteLine(If(False, "TruePart", "FalsePart"))

        Dim number = 3
        ' With number set to 3, this statement prints Positive.
        Console.WriteLine(If(number >= 0, "Positive", "Negative"))

        number = -1
        ' With number set to -1, this statement prints Negative.
        Console.WriteLine(If(number >= 0, "Positive", "Negative"))