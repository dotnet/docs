' *******************************************************
' Snippets from If Operator topic. CLASS 4
Option Infer On

Module Module1

    Sub Main()
        '<Snippet100>
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
        '</Snippet100>

        '<Snippet101>
        number = 12

        ' When the divisor is not 0, both If and IIf return 4.
        Dim divisor = 3
        Console.WriteLine(If(divisor <> 0, number \ divisor, 0))
        Console.WriteLine(IIf(divisor <> 0, number \ divisor, 0))

        ' When the divisor is 0, IIf causes a run-time error, but If does not.
        divisor = 0
        Console.WriteLine(If(divisor <> 0, number \ divisor, 0))
        ' Console.WriteLine(IIf(divisor <> 0, number \ divisor, 0))
        '</Snippet101>

        '<Snippet102>
        ' Variable first is a nullable type.
        Dim first? As Integer = 3
        Dim second As Integer = 6

        ' Variable first <> Nothing, so its value, 3, is returned.
        Console.WriteLine(If(first, second))

        second = Nothing
        ' Variable first <> Nothing, so the value of first is returned again.
        Console.WriteLine(If(first, second))

        first = Nothing
        second = 6
        ' Variable first = Nothing, so 6 is returned.
        Console.WriteLine(If(first, second))
        '</Snippet102>

    End Sub

End Module
