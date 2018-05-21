Option Strict On

Module Module1
    Sub Main()
        ' The assignment of m to n causes a compiler error when 
        ' Option Strict is on.
        Dim m As Long = 987
        'Dim n As Integer = m

        ' The For Each loop requires the same conversion but
        ' causes no errors, even when Option Strict is on.
        For Each number As Integer In New Long() {45, 3, 987}
            Console.Write(number & " ")
        Next
        Console.WriteLine()
        ' Output: 45 3 987

        ' Here a run-time error is raised because 9876543210
        ' is too large for type Integer.
        'For Each number As Integer In New Long() {45, 3, 9876543210}
        '    Console.Write(number & " ")
        'Next

        Console.ReadKey()
    End Sub
End Module