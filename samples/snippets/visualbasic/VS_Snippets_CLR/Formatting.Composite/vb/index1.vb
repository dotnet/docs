' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()

        ' <Snippet7>
        Dim primes As String
        primes = String.Format("Prime numbers less than 10: {0}, {1}, {2}, {3}",
                               2, 3, 5, 7)
        Console.WriteLine(primes)
        ' The example displays the following output:
        '      Prime numbers less than 10: 2, 3, 5, 7
        ' </Snippet7>
        Console.WriteLine()

        ' <Snippet10>
        Dim multiple As String = String.Format("0x{0:X} {0:E} {0:N}",
                                               Int64.MaxValue)
        Console.WriteLine(multiple)
        ' The example displays the following output:
        '      0x7FFFFFFFFFFFFFFF 9.223372E+018 9,223,372,036,854,775,807.00
        ' </Snippet10>
        Console.WriteLine()
    End Sub
End Module

